using System.Collections.Generic;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Map.Query.GetAll
{
    public class IGetAllMapsByOrganisation: IRequest<ResponseModel<List<GetAllMapsByOrganisationResponseModel>>>
    {
        public int OrganisationId { get; set; }
    }
}