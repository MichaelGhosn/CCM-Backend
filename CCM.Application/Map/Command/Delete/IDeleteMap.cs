using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Map.Command.Delete
{
    public class IDeleteMap: IRequest<ResponseModel<DeleteMapResponseModel>>
    {
        public int MapId { get; set; }
    }
}