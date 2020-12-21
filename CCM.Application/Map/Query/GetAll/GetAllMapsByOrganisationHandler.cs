using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Map.Query.GetAll
{
    public class GetAllMapsByOrganisationHandler: IRequestHandler<GetAllMapsByOrganisation, ResponseModel<List<GetAllMapsByOrganisationResponseModel>>>
    {
        private readonly ccmContext _context;

        public GetAllMapsByOrganisationHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<List<GetAllMapsByOrganisationResponseModel>>> Handle(GetAllMapsByOrganisation request, CancellationToken cancellationToken)
        {
            bool doesOrganisationExists =
                _context.Organisation.Any(organisation => organisation.Id == request.OrganisationId);

            if (!doesOrganisationExists)
            {
                return new ResponseModel<List<GetAllMapsByOrganisationResponseModel>>()
                {
                    Success = false,
                    Description = "Organisation does not exists"
                };
            }
            
            return new ResponseModel<List<GetAllMapsByOrganisationResponseModel>>()
            {
                Success = true,
                Data = _context.Map.Where(map => map.OrganisationId == request.OrganisationId).Select(map => new GetAllMapsByOrganisationResponseModel()
                {
                    MapId = map.Id,
                    MapName = map.Name,
                    Image = map.ImagePath,
                    Capacity = map.Capacity,
                    AuthorisedCapacity = 0
                }).ToList(),
                Description = "Successfully fetched organisation maps"
            };
        }
    }
}