using System.ComponentModel.DataAnnotations;
using Classes;
using Enums;
using Microsoft.AspNetCore.Mvc;
using PoSSapi.Tools;

namespace PoSSapi.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceOrderController : GenericController<Order>
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public ActionResult GetAll([FromQuery] string? locationId, [FromQuery] int? status, 
        [FromQuery] int itemsPerPage = 10, [FromQuery] int pageNum = 0)
    {
        if (itemsPerPage <= 0 || pageNum < 0)
        {
            return BadRequest("Invalid itemsPerPage or pageNum");
        }
        
        if (status != null && !Enum.IsDefined(typeof(OrderStatusState), status))
        {
            return BadRequest("Invalid status");
        }

        var objectList = new Order[itemsPerPage];
        for (var i = 0; i < itemsPerPage; i++)
        {
            objectList[i] = RandomGenerator.GenerateRandom<Order>();
            
            if (status != null)
            {
                objectList[i].OrderStatus = (OrderStatusState) status;
            }
        }

        return Ok(objectList);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPatch("{id}")]
    public ActionResult ChangeStatus(string id, [FromQuery] [Required] int status)
    {
        var productOrder = RandomGenerator.GenerateRandom<Order>(id);

        if (!Enum.IsDefined(typeof(OrderStatusState), status))
        {
            return BadRequest("Invalid status");
        }

        var orderStatusState = (OrderStatusState)status;
        productOrder.OrderStatus = orderStatusState;

        return Ok();
    }
}