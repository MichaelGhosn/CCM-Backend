using System.Collections.Generic;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Seat.Query.GetAll
{
    public class IGetAllSeatsByMapId: IRequest<ResponseModel<List<GetAllSeatsByMapIdResponseModel>>>
    {
        public int MapId { get; set; }
    }
}