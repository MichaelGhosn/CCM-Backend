using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CCM.Application.Models;
using MediatR;

namespace CCM.Application.Seat.Command.Add
{
    public class AddSeatToMap: IRequest<ResponseModel<AddSeatToMapResponseModel>>
    {
        [Required]
        public int MapId { get; set; }
        [DefaultValue(0)]
        public int x { get; set; }
        [DefaultValue(0)]
        public int y { get; set; }
        [Required]
        public String Name { get; set; }
    }
}