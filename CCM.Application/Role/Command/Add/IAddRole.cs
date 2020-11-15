using System;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Role.Command.Add
{
    public class IAddRole: IRequest<ResponseModel<AddRoleResponseModel>>
    {
        public String Name { get; set; }
    }
}