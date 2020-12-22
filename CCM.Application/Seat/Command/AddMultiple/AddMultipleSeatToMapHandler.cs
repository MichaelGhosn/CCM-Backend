using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Application.Seat.Command.Add;
using MediatR;

namespace CCM.Application.Seat.Command.AddMultiple
{
    public class AddMultipleSeatToMapHandler: IRequestHandler<AddMultipleSeatToMap, ResponseModel<AddMultipleSeatToMapResponseModel>>
    {
        private IMediator _mediator;

        public AddMultipleSeatToMapHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<ResponseModel<AddMultipleSeatToMapResponseModel>> Handle(AddMultipleSeatToMap request, CancellationToken cancellationToken)
        {
            foreach (var seat in request.Seats)
            {
               await _mediator.Send(seat, cancellationToken);
            }

            return new ResponseModel<AddMultipleSeatToMapResponseModel>()
            {
                Success = true,
                Description = "Added seats"
            };
        }
    }
}