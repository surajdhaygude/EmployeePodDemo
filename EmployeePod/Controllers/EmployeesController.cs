using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeePod.Models;

namespace EmployeePod.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>();

        static EmployeesController()
        {
            employees.Add(new Employee { Id = 1, FirstName = "Suraj", LastName = "Dhaygude", EmailId = "Suraj@gmail.com" });
            employees.Add(new Employee { Id = 2, FirstName = "Kiran", LastName = "Dhaygude", EmailId = "Kiran@gmail.com" });

        }

        public IEnumerable<Employee> Get()
        {
            return employees;
        }
        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)
        {
            return employees.Find(e => e.Id == id);
        }
        [HttpPost]
        public string Post([FromBody] Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException("employee ");
            }
            employees.Add(emp);
            return "Empolyee added ";
        }
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException("emp");
            }
            int Index = employees.FindIndex(p => p.Id == emp.Id);
            if (Index == -1)
            {
                return false;
            }
            employees.RemoveAt(Index);
            employees.Add(emp);
            return true;

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var emp = employees.Find(e => e.Id == id);
            employees.Remove(emp);
        }


    }
}
