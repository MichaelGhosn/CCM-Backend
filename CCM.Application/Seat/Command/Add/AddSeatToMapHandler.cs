using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Seat.Command.Add
{
    public class AddSeatToMapHandler: IRequestHandler<AddSeatToMap, ResponseModel<AddSeatToMapResponseModel>>
    {
        private readonly ccmContext _context;

        public AddSeatToMapHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<AddSeatToMapResponseModel>> Handle(AddSeatToMap request, CancellationToken cancellationToken)
        {
            bool doesMapExists = _context.Map.Any(map => map.Id == request.MapId);

            if (!doesMapExists)
            {
                return new ResponseModel<AddSeatToMapResponseModel>()
                {
                    Success = false,
                    Description = "Map does not exists"
                };
            }

            bool doesCoordinatesExists = _context.Seat.Any(seat =>
                seat.X == request.x && seat.Y == request.y && seat.MapId == request.MapId);

            if (doesCoordinatesExists)
            {
                return new ResponseModel<AddSeatToMapResponseModel>()
                {
                    Success = false,
                    Description = "Coordinates already exist on map"
                };
            }

            int numberOfSeatsExisting = _context.Seat.Where(seat => seat.MapId == request.MapId).Count();
            int numberOfMaxSeats = _context.Map.Where(map => map.Id == request.MapId).Select(map => map.Capacity).FirstOrDefault();

            if (numberOfSeatsExisting >= numberOfMaxSeats)
            {
                return new ResponseModel<AddSeatToMapResponseModel>()
                {
                    Success = false,
                    Description = "Maximum available seats reached its limit"
                };
            }
            
            _context.Seat.Add(new Domain.Seat()
            {
                X = request.x,
                Y = request.y,
                MapId = request.MapId
            });

            await _context.SaveChangesAsync();
            
            return new ResponseModel<AddSeatToMapResponseModel>()
            {
                Success = true,
                Description = "Seat added successfully"
            };

        }
    }
}