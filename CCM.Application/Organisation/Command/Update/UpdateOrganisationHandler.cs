using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Organisation.Command.Update
{
    public class UpdateOrganisationHandler: IRequestHandler<IUpdateOrganisation, ResponseModel<UpdateOrganisationResponseModel>>
    {
        private ccmContext _context;

        public UpdateOrganisationHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<UpdateOrganisationResponseModel>> Handle(IUpdateOrganisation request, CancellationToken cancellationToken)
        {

            Domain.Organisation organisation =
                _context.Organisation.FirstOrDefault(organisation => organisation.Id == request.Id);

            if (organisation == null)
            {
                return new ResponseModel<UpdateOrganisationResponseModel>()
                {
                    Success = false,
                    ErrorDescription = "Organisation does not exists"
                };
            }

            organisation.Name = request.Name;

            _context.Organisation.Update(organisation);
            _context.SaveChangesAsync();
            
            return new ResponseModel<UpdateOrganisationResponseModel>()
            {
                Success = true
            };
            
        }
    }
}