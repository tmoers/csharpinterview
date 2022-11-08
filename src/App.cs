using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interview
{
    internal class App
    {
        static async Task WriteReportToFileAsync(string path, string report)
        {
            var file = System.IO.File.CreateText(path);
            await file.WriteAsync(report);
            file.Close();
        }

        static string CreateReport(List<Employee> employees, ReportType reportType, bool isSummary)
        {
            Report report = new Report { ReportType = reportType };
            var reportString = "";
            if (isSummary)
            {
                reportString = report.CreateSummaryReport(employees);
            }
            else reportString = report.CreateDetailedReport(employees);

            return reportString;
        }

        static Task WriteReportAsync(string path, List<Employee> employees, ReportType reportType, bool isSummary)
        {
            try
            {
                var reportString = CreateReport(employees, reportType, isSummary);
                return WriteReportToFileAsync(path, reportString);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine("Failed to write report: {0}", e.Message);
                throw e;
            }
        }

        static int Main(string[] args)
        {
            EmployeeStore employeeStore = new EmployeeStore();

            var employees = employeeStore.FetchAllEmployeesAsync().Result;
            WriteReportAsync("C:\\reports\\starters.txt", employees, ReportType.HrStarters, true);
            WriteReportAsync("C:\\reports\\salary.txt", employees, ReportType.HrStarters, false).Wait();

            return 0;
        }
    }
}
