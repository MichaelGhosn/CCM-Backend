using System.Threading.Tasks;
using CCM.Application.Day.Command.Add;
using CCM.Application.Day.Command.Delete;
using CCM.Application.Day.Command.Update;
using CCM.Application.Day.Query.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DaysController : BaseController
    {
        // GET
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllDays()));
        }
        
        // ADD
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddDay request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // UPDATE
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateDay request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteDay()
            {
                Id = id 
            }));
        }
    }
}