using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Seat.Command.Delete
{
    public class DeleteSeat: IRequest<ResponseModel<DeleteSeatResponseModel>>
    {
        public int SeatId { get; set; }
    }
}