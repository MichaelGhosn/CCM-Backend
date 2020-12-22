using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Reservation.Command.Delete
{
    public class DeleteReservation: IRequest<ResponseModel<DeleteReservationResponseModel>>
    {
        public int ReservationId { get; set; }
    }
}