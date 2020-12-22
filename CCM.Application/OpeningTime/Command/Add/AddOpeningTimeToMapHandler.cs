using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Application.OpeningTime.Command.Update;
using CCM.Domain;
using MediatR;

namespace CCM.Application.OpeningTime.Command.Add
{
    public class AddOpeningTimeToMapHandler: IRequestHandler<AddOpeningTimeToMap , ResponseModel<AddOpeningTimeToMapResponseModel>>
    {
        private readonly ccmContext _context;
        private IMediator _mediator;

        public AddOpeningTimeToMapHandler(ccmContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        
        public async Task<ResponseModel<AddOpeningTimeToMapResponseModel>> Handle(AddOpeningTimeToMap request, CancellationToken cancellationToken)
        {

            if (request.OpeningHour.CompareTo(request.ClosingHour) >= 0)
            {
                return new ResponseModel<AddOpeningTimeToMapResponseModel>()
                {
                    Success = false,
                    Description = "Closing time should be after opening time"
                };
            }

            bool dayDoesExist = _context.Day.Any(day => day.Id == request.DayId);

            if (!dayDoesExist)
            {
                return new ResponseModel<AddOpeningTimeToMapResponseModel>()
                {
                    Success = false,
                    Description = "Invalid day"
                };
            }

            bool mapDoesExist = _context.Map.Any(map => map.Id == request.MapId);

            if (!mapDoesExist)
            {
                return new ResponseModel<AddOpeningTimeToMapResponseModel>()
                {
                    Success = false,
                    Description = "Invalid map"
                };
            }

            bool doesMapAlreadyHaveOpeningTime = _context.Openingtime.Any(openingtime =>
                openingtime.MapId == request.MapId && openingtime.DayId == request.DayId);

            if (doesMapAlreadyHaveOpeningTime)
            {
                await _mediator.Send(new UpdateOpeningTimeToMap()
                {
                    OpeningTimeId = _context.Openingtime.Where(openingtime =>
                        openingtime.MapId == request.MapId && openingtime.DayId == request.DayId).Select(ot => ot.Id).FirstOrDefault(),
                    OpeningHour = request.OpeningHour,
                    ClosingHour = request.ClosingHour
                }, cancellationToken);
                return new ResponseModel<AddOpeningTimeToMapResponseModel>()
                {
                    Success = false,
                    Description = "Opening time already scheduled for this day on this map, so it has been updated"
                };
            }

            _context.Openingtime.Add(new Openingtime()
            {
                OpeningHour = request.OpeningHour,
                ClosingHour = request.ClosingHour,
                DayId = request.DayId,
                MapId = request.MapId
            });
            await _context.SaveChangesAsync();
            
            
            return new ResponseModel<AddOpeningTimeToMapResponseModel>()
            {
                Success = true,
                Description = "Added opening time on specific day to map"
            };
        }
    }
}