using System.Threading.Tasks;
using CCM.Application.Seat.Command.Add;
using CCM.Application.Seat.Command.Delete;
using CCM.Application.Seat.Query.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : BaseController
    {
        // GET
        [HttpGet("{mapId}")]
        public async Task<IActionResult> GetAllByMapId([FromRoute] int mapId)
        {
            return Ok(await Mediator.Send(new IGetAllSeatsByMapId()
            {
                MapId = mapId
            }));
        }
       
        // ADD
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] IAddSeatToMap request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // DELETE
        [HttpDelete("{seatId}")]
        public async Task<IActionResult> Delete([FromRoute] int seatId)
        {
            return Ok(await Mediator.Send(new IDeleteSeat()
            {
                SeatId = seatId
            }));
        }
    }
}