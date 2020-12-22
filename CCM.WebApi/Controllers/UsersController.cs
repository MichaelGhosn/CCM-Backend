using System.Threading.Tasks;
using CCM.Application.User.Command.Add;
using CCM.Application.User.Command.Delete;
using CCM.Application.User.Command.Update;
using CCM.Application.User.Query.AuthenticateUser;
using CCM.Application.User.Query.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        // GET
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllUsers()));
        }
       
        // ADD
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddUser request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteUser()
            {
                Id = id
            }));
        }
        
        // UPDATE
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateUser request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        
        // Authenticate
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUser request)
        {
            return Ok(await Mediator.Send(request));
        }
        
    }
}