using Microsoft.AspNetCore.Mvc;
using Classes;
using PoSSapi.Tools;
using Enums;

namespace PoSSapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : GenericController<Payment>
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet()]
        public ActionResult GetAll([FromQuery] string? orderId,
            [FromQuery] int itemsPerPage=10, [FromQuery] int pageNum=0)
        { 
            if (itemsPerPage <= 0)
            {
                return BadRequest("itemsPerPage must be greater than 0");
            }

            var objectList = new Payment[itemsPerPage];
            for (int i = 0; i < itemsPerPage; i++)
            {
                objectList[i] = RandomGenerator.GenerateRandom<Payment>();
                if (orderId != null)
                {
                    objectList[i].OrderId = orderId;
                }
            }
            if (orderId != null)
            {
                objectList[0].OrderId = orderId;
            }
            return Ok(objectList);
        }
    }
}
