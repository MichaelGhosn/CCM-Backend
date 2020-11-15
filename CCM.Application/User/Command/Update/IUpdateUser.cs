using System;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.User.Command.Update
{
    public class IUpdateUser: IRequest<ResponseModel<UpdateUserResponseModel>>
    {
        [Required]
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public int RoleId { get; set; }
        public int OrganisationId { get; set; }
    }
}