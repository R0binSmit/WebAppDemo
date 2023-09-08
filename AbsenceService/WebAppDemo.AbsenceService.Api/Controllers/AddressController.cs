using Microsoft.AspNetCore.Mvc;
using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.Address;
using WebAppDemo.AbsenceService.IDataAccess;
using WebAppDemo.AbsenceService.IMappers;

namespace WebAppDemo.AbsenceService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressRepository<Address> _addressRepository;
    private readonly IAddressMapper _addressMapper;

    public AddressController(IAddressRepository<Address> addressRepository, IAddressMapper addressMapper)
    {
        _addressRepository = addressRepository;
        _addressMapper = addressMapper;
    }

    /// <summary>
    /// Get specific address by Id.
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>Specific address.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetAddressDto>> GetAddressById(int id)
    {
        var address = await _addressRepository.GetAsync(id);
        return _addressMapper.Map(address);
    }

    /// <summary>
    /// Get all Addresses from the repository.
    /// </summary>
    /// <returns>Json array of all Addresses.</returns>
    [HttpGet]
    public async Task<ActionResult<List<GetAddressDto>>> GetAddresses()
    {
        var addressess = await _addressRepository.GetAllAsync();
        return _addressMapper.Map(addressess);
    }
}

