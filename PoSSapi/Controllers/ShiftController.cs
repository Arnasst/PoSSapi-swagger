using Microsoft.AspNetCore.Mvc;
using Classes;

namespace PoSSapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController : GenericController<Shift>
    {
    }
}
