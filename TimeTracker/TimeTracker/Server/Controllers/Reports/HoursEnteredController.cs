using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TimeTracker.Server.Models;
using TimeTracker.Shared.Models;

namespace TimeTracker.Server.Controllers.Reports
{
    [ApiController]
    [Authorize(Roles = "Reporting")]
    public class HoursEnteredController : ControllerBase
    {
        [HttpPost]
        [Route("api/reports/hours-entered")]
        public IActionResult Get(HoursEnteredParams Params)
        {
            using var db = new ModelContext();
            return Ok(db.VwHoursEntered
                .Where(x => Params.UserName == null ||
                            Params.UserName == "All" ||
                            x.Username == Params.UserName)
                .Where(x => Params.ProjectTitle == null ||
                            Params.ProjectTitle == "All" ||
                            x.ProjectTitle == Params.ProjectTitle)
                .Where(x => Params.StartDate == null ||
                            x.WorkDate >= Params.StartDate.Value)
                .Where(x => Params.EndDate == null ||
                            x.WorkDate <= Params.EndDate.Value.AddDays(1))
                .ToList());
        }
    }
}
