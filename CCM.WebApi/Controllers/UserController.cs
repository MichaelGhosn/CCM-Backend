using System.Threading.Tasks;
using CCM.Application.User.Command.Add;
using CCM.Application.User.Command.Delete;
using CCM.Application.User.Command.Update;
using CCM.Application.User.Query.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        // GET
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new IGetAllUsers()));
        }
       
        // ADD
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] IAddUser request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new IDeleteUser()
            {
                Id = id
            }));
        }
        
        // UPDATE
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] IUpdateUser request)
        {
            return Ok(await Mediator.Send(request));
        }
        
    }
}