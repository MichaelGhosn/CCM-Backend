using System;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.User.Query.AuthenticateUser
{
    public class IAuthenticateUser: IRequest<ResponseModel<AuthenticateUserResponseModel>>
    {
        public String Email { get; set; }
        public String Password { get; set; }
    }
}