using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TimeTracker.Server.Models;

namespace TimeTracker.Server.Controllers
{
    [Authorize]
    [ApiController]
    public class BillableTypeController : ControllerBase
    {
        [Route("api/billable-types")]
        public IActionResult Get()
        {
            using var db = new ModelContext();

            return Ok(db.BillableType
                .Where(x => x.Deleted == false)
                .ToList());
        }
    }
}
