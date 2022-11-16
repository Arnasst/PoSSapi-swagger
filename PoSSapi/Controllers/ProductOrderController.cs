using Classes;
using Enums;
using Microsoft.AspNetCore.Mvc;
using PoSSapi.Tools;

namespace PoSSapi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductOrderController : GenericController<ProductOrder>
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPatch("{id}")]
    public ActionResult ChangeStatus(string id, int status)
    {
        var productOrder = RandomGenerator.GenerateRandom<ProductOrder>();
        
        if (Enum.IsDefined(typeof(OrderStatusState), status))
        {
            return BadRequest("Invalid status");
        }
        
        var orderStatusState = (OrderStatusState)status;
        productOrder.OrderStatus = orderStatusState;
        
        return Ok();
    }
    
}