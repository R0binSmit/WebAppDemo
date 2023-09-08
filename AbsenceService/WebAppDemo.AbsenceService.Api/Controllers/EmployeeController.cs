using Microsoft.AspNetCore.Mvc;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.Employee;
using WebAppDemo.AbsenceService.IDataAccess;
using WebAppDemo.AbsenceService.IMappers;

namespace WebAppDemo.AbsenceService.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository<Employee> _employeeRepository;
    private readonly IEmployeeMapper _employeeMapper;

    public EmployeeController(IEmployeeRepository<Employee> employeeRepository, IEmployeeMapper employeeMapper)
    {
        _employeeRepository = employeeRepository;
        _employeeMapper = employeeMapper;
    }

    /// <summary>
    /// Get specific employee by id.
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>Specific employee.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetEmployeeDto>> GetEmployeeById(int id)
    {
        var employee = await _employeeRepository.GetAsync(id);
        return _employeeMapper.Map(employee);
    }

    /// <summary>
    /// Get all Employees from the Repository.
    /// </summary>
    /// <returns>Json array of all employees.</returns>
    [HttpGet]
    public async Task<ActionResult<List<GetEmployeeDto>>> GetEmployees()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return _employeeMapper.Map(employees);
    }
}
