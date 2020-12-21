using System;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Role.Command.Delete
{
    public class DeleteRole: IRequest<ResponseModel<DeleteRoleResponseModel>>
    {
        [Required]
        public int Id { get; set; }
    }
}