using System.Threading.Tasks;
using CCM.Application.Reservation.Command.Add;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : BaseController
    {
        // Add
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] IAddReservation request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}