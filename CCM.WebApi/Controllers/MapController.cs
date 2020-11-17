using System;
using System.Threading.Tasks;
using CCM.Application.Map.Command.Add;
using CCM.Application.Map.Command.Delete;
using CCM.Application.Map.Query.GetAll;
using Microsoft.AspNetCore.Mvc;


namespace CCM.WebApi.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class MapController : BaseController
    {
        // GET
        [HttpGet("{organisationId}")]
        public async Task<IActionResult> GetAll([FromRoute] int organisationId)
        {
            return Ok(await Mediator.Send(new IGetAllMapsByOrganisation()
            {
                OrganisationId = organisationId
            }));
        }
        
        // Add
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] IAddMap request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // DELETE
        [HttpDelete("{mapId}")]
        public async Task<IActionResult> Delete([FromRoute] int mapId)
        {
            return Ok(await Mediator.Send(new IDeleteMap()
            {
                MapId = mapId
            }));
        }
        
    }
}