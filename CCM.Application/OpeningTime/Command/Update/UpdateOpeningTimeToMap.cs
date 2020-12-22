using System;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using CCM.Application.OpeningTime.Command.Add;
using MediatR;

namespace CCM.Application.OpeningTime.Command.Update
{
    public class UpdateOpeningTimeToMap: IRequest<ResponseModel<UpdateOpeningTimeToMapResponseModel>>
    {
        [Required]
        public int OpeningTimeId { get; set; }
        [Required]
        public String OpeningHour { get; set; }
        [Required]
        public String ClosingHour { get; set; }
    }
}