using System;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Role.Command.Add
{
    public class AddRole: IRequest<ResponseModel<AddRoleResponseModel>>
    {
        public String Name { get; set; }
    }
}