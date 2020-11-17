using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Seat.Command.Delete
{
    public class DeleteSeatHandler: IRequestHandler<IDeleteSeat, ResponseModel<DeleteSeatResponseModel>>
    {
        private ccmContext _context;

        public DeleteSeatHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<DeleteSeatResponseModel>> Handle(IDeleteSeat request, CancellationToken cancellationToken)
        {
            Domain.Seat seat = _context.Seat.FirstOrDefault(s => s.Id == request.SeatId);

            if (seat == null)
            {
                return new ResponseModel<DeleteSeatResponseModel>()
                {
                    Success = false,
                    Description = "Seat does not exist"
                };
            }

            _context.Seat.Remove(seat);
            _context.SaveChangesAsync();
            
            return new ResponseModel<DeleteSeatResponseModel>()
            {
                Success = true,
                Description = "Seat deleted successfully"
            };
        }
    }
}