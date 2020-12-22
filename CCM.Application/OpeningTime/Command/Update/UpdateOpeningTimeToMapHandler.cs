using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.OpeningTime.Command.Update
{
    public class UpdateOpeningTimeToMapHandler: IRequestHandler<UpdateOpeningTimeToMap, ResponseModel<UpdateOpeningTimeToMapResponseModel>>
    {
        private readonly ccmContext _context;

        public UpdateOpeningTimeToMapHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<UpdateOpeningTimeToMapResponseModel>> Handle(UpdateOpeningTimeToMap request, CancellationToken cancellationToken)
        {
            var openingTime = _context.Openingtime.FirstOrDefault(ot => ot.Id == request.OpeningTimeId);

            if (openingTime == null)
            {
                return new ResponseModel<UpdateOpeningTimeToMapResponseModel>()
                {
                    Success = false,
                    Description = "Invalid opening time id"
                };
            }
            
            if (request.OpeningHour.CompareTo(request.ClosingHour) >= 0)
            {
                return new ResponseModel<UpdateOpeningTimeToMapResponseModel>()
                {
                    Success = false,
                    Description = "Closing time should be after opening time"
                };
            }


            openingTime.OpeningHour = request.OpeningHour;
            openingTime.ClosingHour = request.ClosingHour;

            _context.Openingtime.Update(openingTime);
            
            await _context.SaveChangesAsync();

            return new ResponseModel<UpdateOpeningTimeToMapResponseModel>()
            {
                Success = true,
                Description = "Updated opening hours"
            };
        }
    }
}