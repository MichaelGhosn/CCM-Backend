using System.Threading.Tasks;
using CCM.Application.OpeningTime.Command.Add;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpeningTimeController : BaseController
    {
        // GET
        
        // ADD
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] IAddOpeningTimeToMap request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // UPDATE
        
        // DELETE
    }
}