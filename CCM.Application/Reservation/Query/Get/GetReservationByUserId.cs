using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Reservation.Query.Get
{
    public class GetReservationByUserId: GetReservationByUserIdRequestModel, IRequest<ResponseModel<GetReservationByUserIdResponseModel>>
    {
        [Required]
        public int UserId { get; set; }
    }
}