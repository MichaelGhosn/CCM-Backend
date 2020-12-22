using System.Threading.Tasks;
using CCM.Application.OpeningTime.Command.Add;
using CCM.Application.OpeningTime.Command.Update;
using CCM.Application.OpeningTime.Query.GetAllByOrganisation;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpeningTimesController : BaseController
    {
        // GET
        [HttpGet("{mapId}")]
        public async Task<IActionResult> Get([FromRoute] int mapId)
        {
            return Ok(await Mediator.Send(new GetAllOpeningTimeByOrganisation()
            {
                MapId = mapId
            }));
        }
        
        // ADD
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddOpeningTimeToMap request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // UPDATE
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOpeningTimeToMap request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // DELETE
    }
}