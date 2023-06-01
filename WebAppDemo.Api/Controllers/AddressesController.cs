using Microsoft.AspNetCore.Mvc;
using WebAppDemo.Api.Exceptions;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.Address;
using WebAppDemo.IDataAccess.Repositories;
using WebAppDemo.IMappers;

namespace WebAppDemo.Api.Controllers;

/// <summary>
/// Controller for managing addresses.
/// </summary>
/// <returns>
/// Returns a list of addresses, an address by its id, a created address, an updated address, and a deleted address.
/// </returns>
[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IAddressRepository<Address> _addressRepository;
    private readonly IStateRepository<State> _stateRepository;
    private readonly IAddressMapper _addressMapper;
    public AddressesController(
        IAddressRepository<Address> addressRepository,
        IStateRepository<State> stateRepository,
        IAddressMapper addressMapper)
    {
        _addressRepository = addressRepository;
        _stateRepository = stateRepository;
        _addressMapper = addressMapper;
    }

    /// <summary>
    /// Gets a list of all addresses.
    /// </summary>
    /// <returns>A list of all addresses.</returns>
    [HttpGet]
    public async Task<ActionResult<List<GetAddressDto>>> GetAddresses()
    {
        var addresses = await _addressRepository.GetAllAsync();
        return _addressMapper.Map(addresses);
    }

    /// <summary>
    /// Gets an address by its id.
    /// </summary>
    /// <param name="id">The id of the address.</param>
    /// <returns>The address with the given id.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetAddressDto>> GetAddress(int id)
    {
        var address = await _addressRepository.GetAsync(id);

        if (address == null)
        {
            throw new NotFoundException($"Can't finde Address by given id ({id}).");
        }

        return _addressMapper.Map(address);
    }

    /// <summary>
    /// Creates an address with the given CreateAddressDto.
    /// </summary>
    /// <param name="createAddressDto">The CreateAddressDto containing the address information.</param>
    /// <returns>
    /// The created address as GetAddressDto.
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<GetAddressDto>> CreateAddress(CreateAddressDto createAddressDto)
    {
        var address = _addressMapper.Map(createAddressDto);
        var stateExist = await _stateRepository.ExistsAsync(address.StateId);

        if (stateExist == false)
        {
            throw new NotFoundException($"Can't create address because there is no state with the given stateId ({address.StateId}).");
        }

        await _addressRepository.AddAsync(address);
        var newAddress = _addressRepository.GetAsync(address.Id);

        if (newAddress == null)
        {
            throw new NotFoundException("Can't finde created address.");
        }

        return CreatedAtAction("GetAddress", new { id = address.Id }, _addressMapper.Map(address));
    }

    /// <summary>
    /// Updates an address with the given id.
    /// </summary>
    /// <param name="updateAddressDto">The address to update.</param>
    /// <returns>Returns an OK result if the address was updated successfully.</returns>
    [HttpPut]
    public async Task<ActionResult> UpdateAddress(UpdateAddressDto updateAddressDto)
    {
        var address = _addressMapper.Map(updateAddressDto);
        var addressExist = await _addressRepository.ExistsAsync(address.Id);
        var stateExist = await _stateRepository.ExistsAsync(address.StateId);

        if (addressExist == false)
        {
            throw new NotFoundException($"Can't update address because there is no address with the given id ({address.Id}).");
        }

        if (stateExist == false)
        {
            throw new NotFoundException($"Can't update address because there is no state with the given id ({address.StateId})");
        }

        await _addressRepository.UpdateAsync(address);
        return Ok();
    }

    /// <summary>
    /// Deletes an address with the given id.
    /// </summary>
    /// <param name="id">The id of the address to delete.</param>
    /// <returns>No content if the address was successfully deleted.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAddress(int id)
    {
        var address = await _addressRepository.GetAsync(id);

        if (address == null)
        {
            throw new NotFoundException($"Can't delete address because there is no address with the given id ({id}).");
        }

        await _addressRepository.UpdateAsync(address);
        return NoContent();
    }
}
