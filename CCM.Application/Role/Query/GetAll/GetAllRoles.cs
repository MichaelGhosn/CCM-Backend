using System.Collections.Generic;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Role.Query.GetAll
{
    public class GetAllRoles: IRequest<ResponseModel<List<GetAllRolesResponseModel>>>, IRequest<List<GetAllRolesResponseModel>>
    {
        
    }
}