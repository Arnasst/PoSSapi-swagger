using Classes;
using Microsoft.AspNetCore.Mvc;
using PoSSapi.Tools;

namespace PoSSapi.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceController : GenericController<Service>
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public ActionResult GetAll([FromQuery] string? locationId, [FromQuery] string? categoryId, 
        [FromQuery] int itemsPerPage=10, [FromQuery] int pageNum=0)
    {
        if (itemsPerPage <= 0 || pageNum < 0)
        {
            return BadRequest("Invalid itemsPerPage or pageNum");
        }
        
        int totalItems = 20;  
        int itemsToDisplay = ControllerTools.calculateItemsToDisplay(itemsPerPage, pageNum, totalItems);

        var objectList = new Service[itemsToDisplay];
        for (var i = 0; i < itemsToDisplay; i++)
        {
            objectList[i] = RandomGenerator.GenerateRandom<Service>();
            
            if (locationId != null)
            {
                objectList[i].LocationId = locationId;
            }
            
            if (categoryId != null)
            {
                objectList[i].CategoryId = categoryId;
            }
        }
        
        ReturnObject returnObject = new ReturnObject {totalItems = totalItems, itemList = objectList};
        return Ok(returnObject);
    }
}
