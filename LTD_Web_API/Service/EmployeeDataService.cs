using LTD_Web_API.Data;
using LTD_Web_API.Model;
using Newtonsoft.Json;

namespace LTD_Web_API.Service
{
    public class EmployeeDataService
    {
        API_DBContext dbContext = new API_DBContext();
        public string GetData(string? id, string? firstname, string? lastname, string? ssn)
        {
            List<Employee> data = new List<Employee>();
            IQueryable<Employee> q = dbContext.Employees;
            string output = "";
            try
            {
                if (id == null && firstname == null && lastname == null && ssn == null)
                {
                    return output;
                }
                else
                {
                    if (id != null)
                    {
                        q = q.Where(p => p.EmployeeID == id);
                    }
                    if (firstname != null)
                    {
                        q = q.Where(p => p.FirstName == firstname);
                    }
                    if (lastname != null)
                    {
                        q = q.Where(p => p.LastName == lastname);
                    }
                    if (ssn != null)
                    {
                        q = q.Where(p => p.SSN == ssn);
                    }
                    data = q.ToList();
                }
            }
            catch (Exception e)
            {
                output = "Error: " + e.Message;
                Console.WriteLine(e.Message);
            }

            output = JsonConvert.SerializeObject(data);
            return output;
        }
    }
}
