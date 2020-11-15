using System;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Role.Command.Delete
{
    public class IDeleteRole: IRequest<ResponseModel<DeleteRoleResponseModel>>
    {
        [Required]
        public int Id { get; set; }
    }
}