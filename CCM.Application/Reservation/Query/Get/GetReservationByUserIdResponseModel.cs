using System;
using System.Collections.Generic;

namespace CCM.Application.Reservation.Query.Get
{
    public class GetReservationByUserIdResponseModel
    {
            public List<GetReservationByUserIdModel> Reservations { get; set; }
     
            public int PageNumber { get; set; }
    
            public int PageSize { get; set; }
            
            public int TotalItemCount { get; set; }
    }
}