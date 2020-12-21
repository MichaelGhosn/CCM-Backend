using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Organisation.Command.Update
{
    public class UpdateOrganisationHandler: IRequestHandler<UpdateOrganisation, ResponseModel<UpdateOrganisationResponseModel>>
    {
        private readonly ccmContext _context;

        public UpdateOrganisationHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<UpdateOrganisationResponseModel>> Handle(UpdateOrganisation request, CancellationToken cancellationToken)
        {

            Domain.Organisation organisation =
                _context.Organisation.FirstOrDefault(organisation => organisation.Id == request.Id);

            if (organisation == null)
            {
                return new ResponseModel<UpdateOrganisationResponseModel>()
                {
                    Success = false,
                    Description = "Organisation does not exists"
                };
            }

            organisation.Name = request.Name;

            _context.Organisation.Update(organisation);
            await _context.SaveChangesAsync();
            
            return new ResponseModel<UpdateOrganisationResponseModel>()
            {
                Success = true,
                Description = "Successfully updated organisation"
            };
            
        }
    }
}