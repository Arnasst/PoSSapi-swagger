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
        // GET Shift/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            return Ok(Shift.GenerateRandom(id));
        }

        // POST Shift
        [HttpPost]
        public ActionResult Post([FromBody] Shift shift)
        {
            return CreatedAtAction(nameof(Post), new { id = shift.Id }, shift);
        }

        // PUT <ShiftController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Shift shift)
        {
            return Ok();
        }

        // DELETE <ShiftController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            return Ok();
        }
    }
}
