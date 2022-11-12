using Classes;
using Microsoft.AspNetCore.Mvc;

namespace PoSSapi.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("[controller]")]
public class OrderController : GenericController<Order>
{

}