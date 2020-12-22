using System;

namespace CCM.Application.Reservation.Query.Get
{
    public class GetReservationByUserIdModel
    {
        public int ReservationId { get; set; }
        public DateTime? Date { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        

        public String SeatName { get; set; }
        public String MapName { get; set; }
        public String OrganisationName { get; set; }
        public string Link { get; set; }
    }
}