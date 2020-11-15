using System;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Organisation.Command.Update
{
    public class IUpdateOrganisation: IRequest<ResponseModel<UpdateOrganisationResponseModel>>
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}