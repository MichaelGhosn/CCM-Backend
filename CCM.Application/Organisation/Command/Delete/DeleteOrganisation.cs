using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Organisation.Command.Delete
{
    public class DeleteOrganisation: IRequest<ResponseModel<DeleteOrganisationViewModel>>
    {
        [Required]
        public int Id { get; set; }
    }
}