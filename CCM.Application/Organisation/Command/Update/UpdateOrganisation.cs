using System;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Organisation.Command.Update
{
    public class UpdateOrganisation: IRequest<ResponseModel<UpdateOrganisationResponseModel>>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
    }
}