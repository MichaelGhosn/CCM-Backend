using System.Threading.Tasks;
using CCM.Application.Organisation.Command.Add;
using CCM.Application.Organisation.Command.Delete;
using CCM.Application.Organisation.Command.Update;
using CCM.Application.Organisation.Query.GetAll;
using CCM.Application.Role.Command.Delete;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganisationController : BaseController
    {
        // GET
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllOrganisations()));
        }
        
        
        // ADD
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddOrganisation request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // UPDATE
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateOrganisation request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteOrganisation()
            {
                Id = id
            }));
        }
        
        
    }
}