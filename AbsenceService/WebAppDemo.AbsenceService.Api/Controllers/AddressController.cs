using Microsoft.AspNetCore.Mvc;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.IDataAccess;

namespace WebAppDemo.AbsenceService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressRepository<Address> _addressRepository;

    public AddressController(IAddressRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    /// <summary>
    /// Get all Addresses from the repository.
    /// </summary>
    /// <returns>Json array of all Addresses.</returns>
    [HttpGet]
    public async Task<ActionResult<List<Address>>> GetAddresses()
    {
        return await _addressRepository.GetAllAsync();
    }
}
