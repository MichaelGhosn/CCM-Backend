using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Seat.Command.Add
{
    public class AddSeatToMap: IRequest<ResponseModel<AddSeatToMapResponseModel>>
    {
        public int MapId { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }
}