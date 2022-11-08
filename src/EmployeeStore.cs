using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Interview
{
    public class EmployeeStore
    {
        private static readonly HttpClient client = new HttpClient();

        private Task<string> QueryAsync(string QueryString)
        {
            var url = ConfigurationSingleton.Instance.EmployeeServiceEndpoint + "/" + QueryString;

            try
            {
                return client.GetStringAsync(url);
            }
            catch (Exception e)
            {
              System.Diagnostics.Trace.TraceError("Failed to execute query {0}: {1}", url, e.Message);
              throw e;
            }
        }

        private T Parse<T>(string jsonResponse)
        {
            // Pretend we have a good implementation
            return default(T);
        }

        private async Task<List<string>> FetchEmployeeIdsAsync()
        {
            int thisYear = System.DateTime.Now.Year;
            string queryString = $"listAllEmployees?year={thisYear}";
            string r = QueryAsync(queryString).Result;
            List<string> employeeIds = Parse<List<string>>(r);

            return employeeIds;
        }

        private async Task<Employee> FetchEmployeeAsync(string id)
        {
            string str = $"getEmployee?id={id}";
            string response = await QueryAsync(str);
            return Parse<Employee>(response);
        }

        public async Task<List<Employee>> FetchAllEmployeesAsync()
        {
            var ids = await FetchEmployeeIdsAsync();
            var employeeTasks = ids.Select(id => FetchEmployeeAsync(id));
            var employees = await System.Threading.Tasks.Task.WhenAll(employeeTasks);
            return employees.ToList();
        }
    }
}
