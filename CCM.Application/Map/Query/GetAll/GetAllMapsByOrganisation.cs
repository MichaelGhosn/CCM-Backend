using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Map.Query.GetAll
{
    public class GetAllMapsByOrganisation: IRequest<ResponseModel<List<GetAllMapsByOrganisationResponseModel>>>
    {
        [Required]
        public int OrganisationId { get; set; }
    }
}