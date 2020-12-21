using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.User.Command.Delete
{
    public class DeleteUser: IRequest<ResponseModel<DeleteUserResponseModel>>
    {
        [Required]
        public int Id { get; set; }
    }
}