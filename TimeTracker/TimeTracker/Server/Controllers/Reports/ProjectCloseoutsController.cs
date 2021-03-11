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
    public class ProjectCloseoutsController : ControllerBase
    {
        [HttpPost]
        [Route("api/reports/project-closeouts")]
        public IActionResult Get(ProjectCloseoutsParams Params)
        {
            return Ok(GetData(Params));
        }

        [HttpPost]
        [Route("api/reports/project-closeouts/excel")]
        public IActionResult GetExcel(ProjectCloseoutsParams Params)
        {
            var data = GetData(Params);

            return File(ExcelService.GenerateExcelWorkbook(data), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        private static List<VwProjectCloseouts> GetData(ProjectCloseoutsParams Params)
        {
            using var db = new ModelContext();

            return db.VwProjectCloseouts
                .Where(x => Params.Client == null ||
                            Params.Client == "" ||
                            x.Client == Params.Client)
                .Where(x => Params.ProjectTitle == null ||
                            Params.ProjectTitle == "" ||
                            x.Title == Params.ProjectTitle)
                .Where(x => Params.StartDate == null ||
                            x.DateCreated >= Params.StartDate.Value)
                .Where(x => Params.EndDate == null ||
                            x.DateCreated <= Params.EndDate.Value.AddDays(1))
                .ToList();
        }
    }
}
