using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using CCM.Application.Seat.Command.Add;
using MediatR;

namespace CCM.Application.Seat.Command.AddMultiple
{
    public class AddMultipleSeatToMap: IRequest<ResponseModel<AddMultipleSeatToMapResponseModel>>
    {
        [Required]
        public List<AddSeatToMap> Seats { get; set; }
    }
}