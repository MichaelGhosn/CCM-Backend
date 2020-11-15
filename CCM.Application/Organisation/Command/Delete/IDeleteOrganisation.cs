using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Organisation.Command.Delete
{
    public class IDeleteOrganisation: IRequest<ResponseModel<DeleteOrganisationViewModel>>
    {
        public int Id { get; set; }
    }
}