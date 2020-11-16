using System;
using System.Threading.Tasks;
using CCM.Application.Map.Command.Add;
using Microsoft.AspNetCore.Mvc;


namespace CCM.WebApi.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class MapController : BaseController
    {
        
        // Add
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] IAddMap request)
        {
            return Ok(await Mediator.Send(request));
        }
        
    }
}