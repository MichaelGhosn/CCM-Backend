using System;
using System.Threading.Tasks;
using CCM.Application.Map.Command.Add;
using CCM.Application.Map.Command.Delete;
using CCM.Application.Map.Command.Update;
using CCM.Application.Map.Query.GetAll;
using Microsoft.AspNetCore.Mvc;


namespace CCM.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapsController : BaseController
    {
        // GET
        [HttpGet("{organisationId}")]
        public async Task<IActionResult> GetAll([FromRoute] int organisationId)
        {
            return Ok(await Mediator.Send(new GetAllMapsByOrganisation()
            {
                OrganisationId = organisationId
            }));
        }
        
        // Add
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddMap request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // DELETE
        [HttpDelete("{mapId}")]
        public async Task<IActionResult> Delete([FromRoute] int mapId)
        {
            return Ok(await Mediator.Send(new DeleteMap()
            {
                MapId = mapId
            }));
        }
        
        // UPDATE
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateMap request)
        {
            return Ok(await Mediator.Send(request));
        }
        
    }
}