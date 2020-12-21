using System.Collections.Generic;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.OpeningTime.Query.GetAllByOrganisation
{
    public class GetAllOpeningTimeByOrganisation: IRequest<ResponseModel<List<GetAllOpeningTimeByOrganisationResponseModel>>>
    {
        public int MapId { get; set; }
    }
}