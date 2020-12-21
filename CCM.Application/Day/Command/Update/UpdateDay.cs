using System;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Day.Command.Update
{
    public class UpdateDay: IRequest<ResponseModel<UpdateDayResponseModel>>
    {
        [Required] 
        public int Id { get; set; }
        
        [Required] 
        public String Name { get; set; }
    }
}