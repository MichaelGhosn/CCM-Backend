using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CCM.Application.Map.Command.Update
{
    public class UpdateMap: IRequest<ResponseModel<UpdateMapResponseModel>>
    {
        [Required] 
        public int MapId { get; set; }

        public String Name { get; set; }
        public IFormFile Image { get; set; }
        
        [Range(-1 , Int32.MaxValue)]
        [DefaultValue(-1)]
        public int Capacity { get; set; }
        
        [Range(-1 , 100)]
        [DefaultValue(-1)]
        public int AuthorizedCapacity { get; set; }
    }
}