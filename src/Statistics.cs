using System.Collections.Generic;

namespace Interview
{
    internal class Statistics
    {
        public static int Sum(List<Employee> employees)
        {
            var sum = 0;

            foreach (var employee in employees)
                sum += employee.Salary;

            return sum;
        }

        public static int Average(List<Employee> employees)
        {
            var sum = Sum(employees);
            return sum / employees.Count;
        }
    }
}
