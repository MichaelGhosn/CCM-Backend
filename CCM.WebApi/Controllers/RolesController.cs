using System.Threading.Tasks;
using CCM.Application.Role.Command.Add;
using CCM.Application.Role.Command.Delete;
using CCM.Application.Role.Command.Update;
using CCM.Application.Role.Query.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : BaseController
    {

        // GET
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllRoles()));
        }
        
        // ADD
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddRole request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // UPDATE
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRole request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteRole()
            {
                Id = id
            }));
        }
        
    
        
    }
}