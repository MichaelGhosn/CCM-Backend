using System;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Role.Command.Update
{
    public class IUpdateRole: IRequest<ResponseModel<UpdateRoleResponseModel>>
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}