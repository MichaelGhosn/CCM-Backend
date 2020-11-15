using System;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.User.Command.Add
{
    public class IAddUser: IRequest<ResponseModel<AddUserResponseModel>>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public int RoleId { get; set; }
        public int OrganisationId { get; set; }
    }
}