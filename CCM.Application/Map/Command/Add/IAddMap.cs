using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CCM.Application.Map.Command.Add
{
    public class IAddMap: IRequest<ResponseModel<AddMapResponseModel>>
    {
        [Required]
        public String Name { get; set; }
        
        [Required]
        public IFormFile Image { get; set; }
        
        [Range(0 , Int32.MaxValue)]
        [DefaultValue(0)]
        public int Capacity { get; set; }
        
        [Range(0 , 100)]
        [DefaultValue(0)]
        public int AuthorizedCapacity { get; set; }
        
        [Required]
        public int OrganisationId { get; set; }
        
    }
}