using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TimeTracker.Server.Models;
using TimeTracker.Shared.Models;

namespace TimeTracker.Server.Controllers.Reports
{
    [ApiController]
    [Authorize(Roles = "Reporting")]
    public class MonthSummaryController : ControllerBase
    {
        [HttpPost]
        [Route("api/reports/month-summary/week")]
        public IActionResult GetByWeek(MonthSummaryParams Params)
        {
            DateTime date = new DateTime(DateTime.Now.Year, Params.Month, 1);
            using var db = new ModelContext();
            return Ok(db.MonthSummaryByWeekDto.FromSqlRaw($"EXEC spMonthSummaryByWeekWTotals {date}, {Params.UserName}")
                .ToList());
        }

        [HttpPost]
        [Route("api/reports/month-summary/user")]
        public IActionResult GetByUser(MonthSummaryParams Params)
        {
            DateTime date = new DateTime(DateTime.Now.Year, Params.Month, 1);
            using var db = new ModelContext();
            return Ok(db.MonthSummaryByUserDto.FromSqlRaw($"EXEC spMonthSummaryByUser {date}, {Params.UserName}")
                .ToList());
        }
    }
}
