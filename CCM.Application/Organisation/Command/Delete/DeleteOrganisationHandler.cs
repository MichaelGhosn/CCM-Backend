using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Organisation.Command.Delete
{
    public class DeleteOrganisationHandler: IRequestHandler<DeleteOrganisation, ResponseModel<DeleteOrganisationViewModel>>
    {
        private readonly ccmContext _context;

        public DeleteOrganisationHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<DeleteOrganisationViewModel>> Handle(DeleteOrganisation request, CancellationToken cancellationToken)
        {
            Domain.Organisation organisation =
                _context.Organisation.FirstOrDefault(organisation => organisation.Id == request.Id);

            if (organisation == null)
            {
                return new ResponseModel<DeleteOrganisationViewModel>()
                {
                    Success = false,
                    Description = "Organisation does not exists"
                };
            }

            _context.Organisation.Remove(organisation);

            await _context.SaveChangesAsync();
            
            return new ResponseModel<DeleteOrganisationViewModel>()
            {
                Success = true,
                Description = "Successfully deleted organisation"
            };
        }
    }
}