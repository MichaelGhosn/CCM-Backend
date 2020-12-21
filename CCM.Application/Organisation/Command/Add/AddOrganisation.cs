using System;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Organisation.Command.Add
{
    public class AddOrganisation: IRequest<ResponseModel<AddOrganisationResponseModel>>
    {
        [Required]
        public String Name { get; set; }
    }
}