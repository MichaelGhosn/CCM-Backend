using System;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Day.Command.Add
{
    public class IAddDay: IRequest<ResponseModel<AddDayResponseModel>>
    {
        [Required]
        public String Name { get; set; }
    }
}