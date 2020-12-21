using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Organisation.Command.Add
{
    public class AddOrganisationHandler: IRequestHandler<AddOrganisation, ResponseModel<AddOrganisationResponseModel>>
    {
        private readonly ccmContext _context;

        public AddOrganisationHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<AddOrganisationResponseModel>> Handle(AddOrganisation request, CancellationToken cancellationToken)
        {
            var doesExist =
                _context.Organisation.Any(organisation => organisation.Name.ToLower() == request.Name.ToLower());

            if (doesExist)
            {
                return new ResponseModel<AddOrganisationResponseModel>()
                {
                    Success = false,
                    Description = "Already existing organisation with name " + request.Name
                };
            }

            await _context.Organisation.AddAsync(new Domain.Organisation()
            {
                Name = request.Name
            });

            await _context.SaveChangesAsync();
            
            return new ResponseModel<AddOrganisationResponseModel>()
            {
                Success = true,
                Description = "Successfully added organisation"
            };
        }
    }
}