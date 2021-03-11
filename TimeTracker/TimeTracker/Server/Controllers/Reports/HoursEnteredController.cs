using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Server.Models;
using TimeTracker.Server.Services;
using TimeTracker.Shared.Models.Reports;

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
            return base.Ok(GetData(Params));
        }

        [HttpPost]
        [Route("api/reports/hours-entered/excel")]
        public IActionResult GetExcel(HoursEnteredParams Params)
        {
            var data = GetData(Params);

            return File(ExcelService.GenerateExcelWorkbook(data), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        private static List<VwHoursEntered> GetData(HoursEnteredParams Params)
        {
            using var db = new ModelContext();
            return db.VwHoursEntered
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
                            .ToList();
        }
    }
}
