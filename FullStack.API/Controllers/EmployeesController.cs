using FullStack.API.Data;
using FullStack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
           var employees =  await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult> GetEmployee([FromRoute]Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<ActionResult> updateEmployee([FromRoute] Guid id , Employee updatedEmployee)
        {
            var employee = await _context.Employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            employee.Name = updatedEmployee.Name;
            employee.Email = updatedEmployee.Email;
            employee.Phone = updatedEmployee.Phone;
            employee.Salary = updatedEmployee.Salary;
            employee.Department = updatedEmployee.Department;

            await _context.SaveChangesAsync();

            return Ok(employee);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ActionResult> deleteEmployee(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);

        }

    }
}
