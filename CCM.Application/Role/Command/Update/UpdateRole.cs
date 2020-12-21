using System;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Role.Command.Update
{
    public class UpdateRole: IRequest<ResponseModel<UpdateRoleResponseModel>>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
    }
}