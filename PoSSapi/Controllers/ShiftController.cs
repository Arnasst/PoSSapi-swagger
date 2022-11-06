using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Classes;
using Enums;

namespace PoSSapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController : ControllerBase
    {
        // PUT api/<ShiftController>/5
        [HttpPut("{name}")]
        public ActionResult Put(string id, [FromBody] Shift shift)
        {
            return Ok();
        }

        // DELETE api/<ShiftController>/5
        [HttpDelete("{name}")]
        public ActionResult Delete(string id)
        {
            return Ok();
        }
    }
}
