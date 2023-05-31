using Microsoft.AspNetCore.Mvc;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.Address;
using WebAppDemo.IDataAccess.Repositories;
using WebAppDemo.IMappers;
using WebAppDemo.Mappers;

namespace WebAppDemo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IAddressRepository<Address> _addressRepository;
    private readonly IAddressMapper _addressMapper;
    public AddressesController(
        IAddressRepository<Address> addressRepository,
        IAddressMapper addressMapper) 
    {
        _addressRepository = addressRepository;
        _addressMapper = addressMapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAddressDto>>> GetAddresses()
    {
        var addresses = await _addressRepository.GetAllAsync();
        return _addressMapper.Map(addresses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetAddressDto>> GetAddress(int id)
    {
        var address = await _addressRepository.GetAsync(id);

        if (address == null)
        {
            return NotFound();
        }

        return _addressMapper.Map(address);
    }

    [HttpPost]
    public async Task<ActionResult<GetAddressDto>> CreateAddress(CreateAddressDto createAddressDto)
    {
        var address = _addressMapper.Map(createAddressDto);
        await _addressRepository.AddAsync(address);
        return CreatedAtAction("GetAddress", new { id = address.Id }, _addressMapper.Map(address));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAddress(UpdateAddressDto updateAddressDto)
    {
        // Todo: Fix Bug
        var address = _addressMapper.Map(updateAddressDto);
        var addressExist = await _addressRepository.ExistsAsync(address.Id);


        if (updateAddressDto.Id != address.Id || addressExist == false)
        {
            return BadRequest();
        }

        await _addressRepository.UpdateAsync(address);
        return Ok();
    }


}
