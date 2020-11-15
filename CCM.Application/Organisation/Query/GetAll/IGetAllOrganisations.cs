using System.Collections.Generic;
using CCM.Application.Models;
using CCM.Application.Role.Query.GetAll;
using MediatR;

namespace CCM.Application.Organisation.Query.GetAll
{
    public class IGetAllOrganisations: IRequest<ResponseModel<List<GetAllOrganisationsResponseModel>>>
    {
        
    }
}