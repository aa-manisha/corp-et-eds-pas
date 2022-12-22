using LTD_Web_API.Controllers;
using LTD_Web_API.Model;
using LTD_Web_API.Service;
using Shouldly;

namespace LTD_Test_Api
{
    public class UnitTest1
    {
        EmployeesController empController = new();
        EmployeeDataService dataService = new();

        [Fact]
        public void Get_Employee_Data_null()
        {
            var EmployeeList = empController.GetEmployeeData(null,null,null,null);
            var ActualList = _controller.GetCalculationFormData(id);
            string ExpectedList = dataService.GetCalculationFormData(id);
            Assert.IsType<OkObjectResult>(ActualList);
            Assert.Equal(ExpectedList, ((ObjectResult)ActualList).Value);

        }
        [Theory]
        [InlineData("10000")]
        [InlineData("10011")]
        public void Get_Employee_Data_ID(string empid)
        {
            List<Employee> EmployeeList = empController.GetEmployeeData(empid, null, null, null);
            List<Employee> ExpectedList = dataService.GetData(empid, null, null, null);
            Assert.Single(EmployeeList);
            EmployeeList.ShouldBeEquivalentTo(ExpectedList);
            
        }

        [Theory]
        [InlineData("10000", "John")]
        [InlineData("10011", "Ben")]
        public void Get_Employee_Data_ID_FName(string empid, string fname)
        {
            List<Employee> EmployeeList = empController.GetEmployeeData(empid, fname, null, null);
            List<Employee> ExpectedList = dataService.GetData(empid, fname, null, null);
            Assert.Equal(ExpectedList.Count, EmployeeList.Count);
            EmployeeList.ShouldBeEquivalentTo(ExpectedList);
        }

        [Theory]
        [InlineData("John")]
        public void Get_Employee_Data_FName(string fname)
        {
            List<Employee> EmployeeList = empController.GetEmployeeData(null, fname, null, null);
            List<Employee> ExpectedList = dataService.GetData(null, fname, null, null);
            Assert.Equal(ExpectedList.Count, EmployeeList.Count);
            EmployeeList.ShouldBeEquivalentTo(ExpectedList);
        }

        [Theory]
        [InlineData("Doe")]
        public void Get_Employee_Data_LName(string lname)
        {
            List<Employee> EmployeeList = empController.GetEmployeeData(null, null, lname, null);
            List<Employee> ExpectedList = dataService.GetData(null, null, lname, null);
            Assert.Equal(ExpectedList.Count, EmployeeList.Count);
            EmployeeList.ShouldBeEquivalentTo(ExpectedList);
        }

        [Theory]
        [InlineData("1237")]
        [InlineData("1234")]
        public void Get_Employee_Data_SSN(string SSN)
        {
            List<Employee> EmployeeList = empController.GetEmployeeData(null, null, null, SSN);
            List<Employee> ExpectedList = dataService.GetData(null, null, null, SSN);
            Assert.Equal(ExpectedList.Count, EmployeeList.Count);
            EmployeeList.ShouldBeEquivalentTo(ExpectedList);
        }

        [Theory]
        [InlineData("John","Doe")]
        public void Get_Employee_Data_FName_LName(string fname, string lname)
        {
            List<Employee> EmployeeList = empController.GetEmployeeData(null, fname, lname, null);
            List<Employee> ExpectedList = dataService.GetData(null, fname, lname, null);
            Assert.Equal(ExpectedList.Count, EmployeeList.Count);
            EmployeeList.ShouldBeEquivalentTo(ExpectedList);
        }
    }
}