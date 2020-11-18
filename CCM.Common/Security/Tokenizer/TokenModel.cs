using System;

namespace CCM.Common.Security.Tokenizer
{
    public class TokenModel
    {
        public int UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public int? RoleId { get; set; }
        public String RoleName { get; set; }
        public int? OrganisationId { get; set; }
        public String OrganisationName { get; set; }
    }
}