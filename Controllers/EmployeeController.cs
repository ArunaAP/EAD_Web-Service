using Microsoft.AspNetCore.Mvc;
using TicketBooking.Models;
using TicketBooking.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return employeeService.Get();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(string id)
        {
            var employee = employeeService.Get(id);

            if(employee == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            return employee;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            employeeService.Create(employee);

            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Employee employee)
        {
            var existingEmployee = employeeService.Get(id);

            if (existingEmployee == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            employeeService.Update(id, employee);

            return NoContent();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var employee = employeeService.Get(id);

            if (employee == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            employeeService.Remove(employee.Id);

            return Ok($"Student with Id = {id} deleted");
        }
    }
}
