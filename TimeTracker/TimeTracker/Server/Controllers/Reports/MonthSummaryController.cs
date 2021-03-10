using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@date", Value = date },
                new SqlParameter { ParameterName = "@userName", Value = Params.UserName }
            };

            return Ok(db.MonthSummaryByWeekDto.FromSqlRaw($"EXEC spMonthSummaryByWeekWTotals @date, @userName", parms.ToArray())
                .ToList());
        }

        [HttpPost]
        [Route("api/reports/month-summary/user")]
        public IActionResult GetByUser(MonthSummaryParams Params)
        {
            DateTime date = new DateTime(DateTime.Now.Year, Params.Month, 1);
            using var db = new ModelContext();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@date", Value = date },
                new SqlParameter { ParameterName = "@userName", Value = Params.UserName }
            };

            return Ok(db.MonthSummaryByUserDto.FromSqlRaw($"EXEC spMonthSummaryByUser @date, @userName", parms.ToArray())
                .ToList());
        }
    }
}
