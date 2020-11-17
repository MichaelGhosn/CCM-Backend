using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Seat.Command.Add
{
    public class AddSeatToMapHandler: IRequestHandler<IAddSeatToMap, ResponseModel<AddSeatToMapResponseModel>>
    {
        private ccmContext _context;

        public AddSeatToMapHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<AddSeatToMapResponseModel>> Handle(IAddSeatToMap request, CancellationToken cancellationToken)
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

            _context.Seat.Add(new Domain.Seat()
            {
                X = request.x,
                Y = request.y,
                MapId = request.MapId
            });

            _context.SaveChangesAsync();
            
            return new ResponseModel<AddSeatToMapResponseModel>()
            {
                Success = true,
                Description = "Seat added successfully"
            };

        }
    }
}