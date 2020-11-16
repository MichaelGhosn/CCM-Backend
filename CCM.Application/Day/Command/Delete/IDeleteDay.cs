using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Day.Command.Delete
{
    public class IDeleteDay: IRequest<ResponseModel<DeleteDayResponseModel>>
    {
        [Required]
        public int Id { get; set; }
    }
}