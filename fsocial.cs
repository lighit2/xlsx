using System;
using OfficeOpenXml; // Requires EPPlus NuGet package

class Program
{
    static void Main(string[] args)
    {
        // Sample data to export
        var data = new[]
        {
            new { Name = "Alice", Age = 30 },
            new { Name = "Bob", Age = 25 }
        };

        // Set license context for EPPlus
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Sheet1");

            // Add headers
            worksheet.Cells[1, 1].Value = "Name";
            worksheet.Cells[1, 2].Value = "Age";

            // Add data
            for (int i = 0; i < data.Length; i++)
            {
                worksheet.Cells[i + 2, 1].Value = data[i].Name;
                worksheet.Cells[i + 2, 2].Value = data[i].Age;
            }

            // Save to file
            var filePath = "output.xlsx";
            package.SaveAs(new FileInfo(filePath));
            Console.WriteLine($"Excel file exported to {filePath}");
        }
    }
}