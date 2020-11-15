using System;

namespace CCM.Application.User.Query.GetAll
{
    public class GetAllUsersResponseModel
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public UserRoleResponseModel Role { get; set; }
        public UserOrganisationResponseModel Organisation { get; set; }
    }
    
}