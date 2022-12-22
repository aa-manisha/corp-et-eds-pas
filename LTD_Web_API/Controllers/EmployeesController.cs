using LTD_Web_API.Data;
using LTD_Web_API.Model;
using LTD_Web_API.Service;
using Microsoft.AspNetCore.Mvc;


namespace LTD_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        EmployeeDataService dataService = new EmployeeDataService();

        // GET api/<EmployeesController>/data?id=1
        [HttpGet]
        [Route("data")]
        public IActionResult GetEmployeeData(string? id, string? firstname, string? lastname, string? ssn)
        {
            string data;
            try
            {
                data = dataService.GetData(id, firstname, lastname, ssn);
                if (!data.Contains("Error"))
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest(data);
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
            
           
        }
    }
}
