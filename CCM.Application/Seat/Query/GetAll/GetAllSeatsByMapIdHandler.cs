using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Seat.Query.GetAll
{
    public class GetAllSeatsByMapIdHandler: IRequestHandler<GetAllSeatsByMapId, ResponseModel<List<GetAllSeatsByMapIdResponseModel>>>
    {
        private readonly ccmContext _context;

        public GetAllSeatsByMapIdHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<List<GetAllSeatsByMapIdResponseModel>>> Handle(GetAllSeatsByMapId request, CancellationToken cancellationToken)
        {
            bool mapDoesExists = _context.Map.Any(map => map.Id == request.MapId);

            if (!mapDoesExists)
            {
                return new ResponseModel<List<GetAllSeatsByMapIdResponseModel>>()
                {
                    Success = false,
                    Description = "Map does not exists"
                };
            }
            
            return new ResponseModel<List<GetAllSeatsByMapIdResponseModel>>()
            {
                Success = true,
                Data = _context.Seat.Where(seat => seat.MapId == request.MapId).Select(seat => new GetAllSeatsByMapIdResponseModel()
                {
                    SeatId = seat.Id,
                    x = seat.X,
                    y = seat.Y,
                    Name = seat.Name
                }).ToList(),
                Description = "Fetched data successfully"
            };
        }
    }
}