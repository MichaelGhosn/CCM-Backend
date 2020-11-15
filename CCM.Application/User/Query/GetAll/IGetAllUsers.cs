using System.Collections.Generic;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.User.Query.GetAll
{
    public class IGetAllUsers: IRequest<ResponseModel<List<GetAllUsersResponseModel>>>
    {
        
    }
}