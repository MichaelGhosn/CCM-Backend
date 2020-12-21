using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CCM.Application.Map.Command.Delete
{
    public class DeleteMapHandler: IRequestHandler<DeleteMap, ResponseModel<DeleteMapResponseModel>>
    {
        private readonly ccmContext _context;

        public DeleteMapHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<DeleteMapResponseModel>> Handle(DeleteMap request, CancellationToken cancellationToken)
        {
            Domain.Map map = _context.Map.Include(map => map.Seat).ThenInclude(seat => seat.Reservation).Include(map => map.Openingtime).FirstOrDefault(m => m.Id == request.MapId);

            if (map == null)
            {
                return new ResponseModel<DeleteMapResponseModel>()
                {
                    Success = false,
                    Description = "Map does not exist"
                };
            }
            
            foreach (var seat in map.Seat)
            {
                _context.Reservation.RemoveRange(seat.Reservation);
            }
            _context.Seat.RemoveRange(map.Seat);
            
            
            _context.Map.Remove(map);
            await _context.SaveChangesAsync();
            
            return new ResponseModel<DeleteMapResponseModel>()
            {
                Success = true,
                Description = "Map has been deleted"
            };
        }
    }
}