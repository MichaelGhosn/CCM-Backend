using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Organisation.Query.GetAll
{
    public class GetAllOrganisationsHandler: IRequestHandler<IGetAllOrganisations, ResponseModel<List<GetAllOrganisationsResponseModel>>>
    {
        private ccmContext _context;

        public GetAllOrganisationsHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<List<GetAllOrganisationsResponseModel>>> Handle(IGetAllOrganisations request, CancellationToken cancellationToken)
        {
            return new ResponseModel<List<GetAllOrganisationsResponseModel>>()
            {
                Success = true,
                Data = _context.Organisation.Select(organisation => new GetAllOrganisationsResponseModel()
                {
                    Id = organisation.Id,
                    Name = organisation.Name
                }).ToList()
            };
        }
    }
}