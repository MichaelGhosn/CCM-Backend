using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Organisation.Command.Add
{
    public class AddOrganisationHandler: IRequestHandler<IAddOrganisation, ResponseModel<AddOrganisationResponseModel>>
    {
        private ccmContext _context;

        public AddOrganisationHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<AddOrganisationResponseModel>> Handle(IAddOrganisation request, CancellationToken cancellationToken)
        {
            var doesExist =
                _context.Organisation.Any(organisation => organisation.Name.ToLower() == request.Name.ToLower());

            if (doesExist)
            {
                return new ResponseModel<AddOrganisationResponseModel>()
                {
                    Success = false,
                    ErrorDescription = "Already existing organisation with name " + request.Name
                };
            }

            _context.Organisation.AddAsync(new Domain.Organisation()
            {
                Name = request.Name
            });

            _context.SaveChangesAsync();
            
            return new ResponseModel<AddOrganisationResponseModel>()
            {
                Success = true
            };
        }
    }
}