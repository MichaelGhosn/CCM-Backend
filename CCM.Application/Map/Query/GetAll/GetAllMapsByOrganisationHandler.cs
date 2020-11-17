using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Map.Query.GetAll
{
    public class GetAllMapsByOrganisationHandler: IRequestHandler<IGetAllMapsByOrganisation, ResponseModel<List<GetAllMapsByOrganisationResponseModel>>>
    {
        private ccmContext _context;

        public GetAllMapsByOrganisationHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<List<GetAllMapsByOrganisationResponseModel>>> Handle(IGetAllMapsByOrganisation request, CancellationToken cancellationToken)
        {
            return new ResponseModel<List<GetAllMapsByOrganisationResponseModel>>()
            {
                Success = true,
                Data = _context.Map.Where(map => map.OrganisationId == request.OrganisationId).Select(map => new GetAllMapsByOrganisationResponseModel()
                {
                    MapId = map.Id,
                    MapName = map.Name,
                    Image = map.ImagePath,
                    Capacity = map.Capacity ?? 0,
                    AuthorisedCapacity = map.AuthorizedCapacity ?? 0
                }).ToList(),
                Description = "Successfully fetched data"
            };
        }
    }
}