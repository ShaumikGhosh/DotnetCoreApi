using CoreWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi.Models;


namespace CoreWebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;



        public TestController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }



        [Route("employees")]
        [HttpGet]
        public async Task<ActionResult<Employee>> GetEmployees()
        {
            try
            {
                return Ok(await _employeeRepository.GellAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in gettting data");
            }
        }


        [HttpGet]
        [Route("employee/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                return Ok(await _employeeRepository.GetById(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in gettting data");
            }
        }



        [HttpPost]
        [Route("add-employee")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                var createdEmployee = await _employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in inserting data");
            }
        }





        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult<Employee>> EditEmployee(int id, Employee employee)
        {
            try
            {
                return Ok(await _employeeRepository.UpdateEmployee(id, employee));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in inserting data");
            }
        }



        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                return Ok(await _employeeRepository.DeleteEmployee(id));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in inserting data");
            }
        }




    }
}
