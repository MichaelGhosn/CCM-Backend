using System;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Organisation.Command.Add
{
    public class IAddOrganisation: IRequest<ResponseModel<AddOrganisationResponseModel>>
    {
        public String Name { get; set; }
    }
}