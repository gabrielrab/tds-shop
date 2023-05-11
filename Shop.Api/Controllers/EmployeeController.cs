using Microsoft.AspNetCore.Mvc;
using Shop.Api.Models;
using Shop.Api.Repository;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController(Context context)
        {
            _employeeRepository = new EmployeeRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeModel employee)
        {
            await _employeeRepository.Add(employee);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmployeeModel employee)
        {
            await _employeeRepository.Update(employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.RemoveById(id);
            return Ok();
        }
    }
}