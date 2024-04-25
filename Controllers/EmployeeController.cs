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
        public IActionResult AddEmployee(AddEmployeeRequest form)
        {
            var context = _context;

            var name = form.Name;
            var position = form.Position;
            var bankId = form.BankId;

            new AddEmployeeRequest
            {
                BankId = bankId,
                Position = position,
                Name = name
            };

            context.Employees.Add(new Employee
            {
                Name = form.Name,
                Position = form.Position,
                CivilId = form.CivilId,
                BankBranch = context.bankBranchTable.Find(form.BankId)
            });
            context.SaveChanges();

            return Created();
        }


        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var bank = _context.Employees.Include(b => b.BankBranch).SingleOrDefault(b => b.Id == id);
            if (bank == null)
            {
                return NotFound();
            }
            return Ok(new EmployeeDetails
            {
                BankId = bank.BankBranch.BankId,
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
        public IActionResult Edit(int id, EditEmployee request)
        {
            var employee = _context.Employees.Find(id);
            employee.Name = request.Name;
            employee.Position = request.Position;
            employee.BankBranch = _context.bankBranchTable.Find(request.BankId);
            _context.SaveChanges();
            return Created(nameof(Details), new { Id = employee.Id });
        }
    }
}

