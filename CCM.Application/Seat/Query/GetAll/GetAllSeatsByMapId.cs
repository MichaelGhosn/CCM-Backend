using System.Collections.Generic;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Seat.Query.GetAll
{
    public class GetAllSeatsByMapId: IRequest<ResponseModel<List<GetAllSeatsByMapIdResponseModel>>>
    {
        public int MapId { get; set; }
    }
}