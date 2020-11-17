using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Map.Command.Delete
{
    public class IDeleteMap: IRequest<ResponseModel<DeleteMapResponseModel>>
    {
        [Required]
        public int MapId { get; set; }
    }
}