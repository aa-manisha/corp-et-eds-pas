using LTD_Web_API.Model;
using Microsoft.EntityFrameworkCore;

namespace LTD_Web_API.Data
{
    public class API_DBContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EmployeesSearchDB");

        }
    }
}
