using System;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.OpeningTime.Command.Add
{
    public class IAddOpeningTimeToMap: IRequest<ResponseModel<AddOpeningTimeToMapResponseModel>>
    {
        public String OpeningHour { get; set; }
        public String ClosingHour { get; set; }
        public int MapId { get; set; }
        public int DayId { get; set; }
    }
}