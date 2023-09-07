using Microsoft.AspNetCore.Mvc;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.IDataAccess;

namespace WebAppDemo.AbsenceService.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository<Employee> _employeeRepository;

    public EmployeeController(IEmployeeRepository<Employee> employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    /// <summary>
    /// Get all Employees from the Repository.
    /// </summary>
    /// <returns>Json array of all employees.</returns>
    [HttpGet]
    public async Task<ActionResult<List<Employee>>> GetEmployees()
    {
        return await _employeeRepository.GetAllAsync();
    }
}
