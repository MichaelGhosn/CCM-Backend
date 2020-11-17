using System;

namespace CCM.Application.Map.Query.GetAll
{
    public class GetAllMapsByOrganisationResponseModel
    {
        public int MapId { get; set; }
        public String MapName { get; set; }
        public String Image { get; set; }
        public int Capacity { get; set; }
        public int AuthorisedCapacity { get; set; }
    }
}