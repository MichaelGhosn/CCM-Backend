using System.Threading.Tasks;
using CCM.Application.Reservation.Command.Add;
using CCM.Application.Reservation.Command.Delete;
using CCM.Application.Reservation.Query.Get;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : BaseController
    {
        // Add
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddReservation request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        //Get
        [HttpPost("{userId}")]
        public async Task<IActionResult> GetByUserId([FromBody] GetReservationByUserIdRequestModel request, [FromRoute] int userId)
        {
            return Ok(await Mediator.Send(new GetReservationByUserId()
            {
                UserId = userId,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            }));
        }
        
        //Delete
        [HttpDelete("{reservationId}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] int reservationId)
        {
            return Ok(await Mediator.Send(new DeleteReservation()
            {
                ReservationId = reservationId
            }));
        }
    }
}