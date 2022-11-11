using Microsoft.AspNetCore.Mvc;
using Classes;
using PoSSapi.Tools;

namespace PoSSapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController : GenericController<Shift>
    {
        [HttpGet("{employee_id}")]
        public ActionResult Get(string employee_id)
        {
            var objectList = new Shift[] { RandomGenerator.GenerateRandom<Shift>() };
            objectList[0].EmployeeId = employee_id;
            return Ok(objectList);
        }
    }
}
