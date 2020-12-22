using System;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Reservation.Command.Add
{
    public class AddReservation: IRequest<ResponseModel<AddEventToReservationResponseModelModel>>
    {
        public int UserId { get; set; }
        public int SeatId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; } 
    }
}