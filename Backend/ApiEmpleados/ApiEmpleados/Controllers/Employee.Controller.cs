using Microsoft.AspNetCore.Mvc;
using ApiEmpleados.Models;
using ApiEmpleados.Services;
using ApiEmpleados.Functions;
using Microsoft.Extensions.Configuration;

namespace ApiEmpleados.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeServices _employeeService;
        private readonly GeneralFunctions _functionsGeneral;
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration, EmployeeServices employeeService)
        {
            _configuration = configuration;
            _employeeService = employeeService;
            _functionsGeneral = new GeneralFunctions(configuration);
        }

        [HttpPost("Register")]
        public IActionResult Create([FromBody] EmployeeModel entity)
        {
            try
            {
                _employeeService.Add(entity);
                return Ok("Registrado con éxito");
            }
            catch (Exception ex)
            {
                _functionsGeneral.AddLog(ex.Message);
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("GetEmployees")]
        public ActionResult<IEnumerable<EmployeeModel>> GetEmployee()
        {
            try
            {
                var employees = _employeeService.GetEmployee();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _functionsGeneral.AddLog(ex.Message);
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
