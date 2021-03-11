using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TimeTracker.Server.Models;
using TimeTracker.Shared.Models.Reports;

namespace TimeTracker.Server.Controllers.Reports
{
    [ApiController]
    [Authorize(Roles = "Reporting")]
    public class MonthSummaryController : ControllerBase
    {
        [HttpPost]
        [Route("api/reports/month-summary/excel")]
        public IActionResult GetExcel(MonthSummaryParams Params)
        {
            var stream = new MemoryStream();

            using var package = new ExcelPackage(stream);

            var weekWorkSheet = package.Workbook.Worksheets.Add("byWeek");

            var weekData = GetWeekData(Params);
            weekWorkSheet.Cells.LoadFromCollection(weekData, true);

            var usersWorkSheet = package.Workbook.Worksheets.Add("byUsers");

            var userData = GetUsersData(Params);
            usersWorkSheet.Cells.LoadFromCollection(userData, true);

            return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

        }

        [HttpPost]
        [Route("api/reports/month-summary/week")]
        public IActionResult GetByWeek(MonthSummaryParams Params)
        {
            return base.Ok(GetWeekData(Params));
        }

        private static List<MonthSummaryByWeekDto> GetWeekData(MonthSummaryParams parms)
        {
            DateTime date = new DateTime(DateTime.Now.Year, parms.Month, 1);
            using var db = new ModelContext();

            List<SqlParameter> sqlParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@date", Value = date },
                new SqlParameter { ParameterName = "@userName", Value = parms.UserName }
            };

            return db.MonthSummaryByWeekDto.FromSqlRaw($"EXEC spMonthSummaryByWeekWTotals @date, @userName", sqlParams.ToArray())
                            .ToList();
        }

        [HttpPost]
        [Route("api/reports/month-summary/user")]
        public IActionResult GetByUser(MonthSummaryParams Params)
        {
            return Ok(GetUsersData(Params));
        }

        private List<MonthSummaryByUserDto> GetUsersData(MonthSummaryParams Params)
        {
            DateTime date = new DateTime(DateTime.Now.Year, Params.Month, 1);
            using var db = new ModelContext();
            List<SqlParameter> sqlParams = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@date", Value = date },
                new SqlParameter { ParameterName = "@userName", Value = Params.UserName }
            };

            return db.MonthSummaryByUserDto.FromSqlRaw($"EXEC spMonthSummaryByUser @date, @userName", sqlParams.ToArray())
                .ToList();
        }
    }
}
