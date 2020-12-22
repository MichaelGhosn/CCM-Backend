using System.ComponentModel;

namespace CCM.Application.Reservation.Query.Get
{
    public class GetReservationByUserIdRequestModel
    {
        [DefaultValue(0)]
        public int PageNumber { get; set; }
        [DefaultValue(10)]
        public int PageSize { get; set; }
    }
}