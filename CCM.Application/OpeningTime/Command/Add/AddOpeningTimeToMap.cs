using System;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.OpeningTime.Command.Add
{
    public class AddOpeningTimeToMap: IRequest<ResponseModel<AddOpeningTimeToMapResponseModel>>
    {
        [Required]
        public String OpeningHour { get; set; }
        [Required]
        public String ClosingHour { get; set; }
        [Required]
        public int MapId { get; set; }
        [Required]
        public int DayId { get; set; }
    }
}