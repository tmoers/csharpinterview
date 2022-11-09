using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public enum ReportType
    {
        HrStarters,
        SalaryStatistics,
        // More are coming!
    }

    public class Report
    {
        public ReportType ReportType { get; set; }

        private static IEnumerable<Employee> FilterStarters(IEnumerable<Employee> employees)
        {
            var minStartDate = System.DateTime.Now.AddMonths(-1);
            List<Employee> starters = new List<Employee>();
            foreach (Employee employee in employees.ToList())
            {
                if (minStartDate <= employee.StartDate)
                    starters.Add(employee);
            }
            return employees.ToList();
        }

        public string CreateDetailedReport(IEnumerable<Employee> employees)
        {
            switch (ReportType)
            {
                case ReportType.HrStarters:
                    var starters = FilterStarters(employees).ToList();
                    var starterNames = starters.Select(starter => starter.Name).ToList();
                    var header = $"The following {starterNames.Count} people started this month";
                    var body = string.Join("\n- ", starterNames);
                    return header + "\n" + body;

                case ReportType.SalaryStatistics:
                    var total = Statistics.Sum(employees.ToList());
                    var avg = Statistics.Average(employees.ToList());
                    return $"Our {employees.ToList().Count} employees earn on average {avg}, totaling a cost of {total}";

                default:
                    throw new Exception("Invalid report type");
            }
        }

        public string CreateSummaryReport(IEnumerable<Employee> employees)
        {
            switch (ReportType)
            {
                case ReportType.HrStarters:
                    var starters = FilterStarters(employees).ToList();
                    return $"We have {starters.Count} starters this month!";

                case ReportType.SalaryStatistics:
                    var total = Statistics.Sum(employees.ToList());
                    return $"Our payroll cast totals {total}";

                default:
                    throw new Exception("Invalid report type");
            }
        }
    }

}
