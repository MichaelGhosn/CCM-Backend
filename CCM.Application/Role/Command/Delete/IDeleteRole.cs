using System;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Role.Command.Delete
{
    public class IDeleteRole: IRequest<ResponseModel<DeleteRoleResponseModel>>
    {
        public int Id { get; set; }
    }
}