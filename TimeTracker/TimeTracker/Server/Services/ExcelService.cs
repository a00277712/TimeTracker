using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace TimeTracker.Server.Services
{
    public static class ExcelService
    {
        public static byte[] GenerateExcelWorkbook<T>(List<T> list)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");

                workSheet.Cells.LoadFromCollection(list, true);

                return package.GetAsByteArray();
            }
        }
    }
}
