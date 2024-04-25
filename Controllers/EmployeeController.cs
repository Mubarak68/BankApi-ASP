using Bank_Branch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly BankContext _context;

        public EmployeeController(BankContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult AddEmployee(Employee form)
        {
            var context = _context;

            var name = form.Name;
            var position = form.Position;
            var bankBranch = form.BankBranch;



            context.Employees.Add(new Employee
            {
                Name = name,
                Position = position,
                BankBranch = bankBranch
            });
            context.SaveChanges();

            return Created();
        }


        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var bank = _context.Employees.Find(id);
            if (bank == null)
            {
                return NotFound();
            }
            return Ok(new Employee
            {
                BankBranch = bank.BankBranch,
                Position = bank.Position,
                Name = bank.Name
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Created(nameof(Details), new { Id = employee.Id });
        }


        [HttpPatch("{id}")]
        public IActionResult Edit(int id, Employee request)
        {
            var employee = _context.Employees.Find(id);
            employee.Name = request.Name;
            employee.Position = request.Position;
            employee.BankBranch = request.BankBranch;
            _context.SaveChanges();
            return Created(nameof(Details), new { Id = employee.Id });
        }
    }
}

