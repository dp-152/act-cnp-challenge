using AutoMapper;
using CnpChallenge.API.DTO.Cliente;
using CnpChallenge.Application.Contracts.DTO.Feature.ClienteServices;
using CnpChallenge.Application.Contracts.Interfaces.Feature;
using Microsoft.AspNetCore.Mvc;

namespace CnpChallenge.API.Controllers;

public class ClienteController : _BaseController
{
    private readonly IMapper _mapper;
    private readonly IClienteServices _clienteServices;

    public ClienteController(IMapper mapper, IClienteServices clienteServices)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _clienteServices = clienteServices ?? throw new ArgumentNullException(nameof(clienteServices));
    }

    [HttpGet]
    [ProducesDefaultResponseType(typeof(IEnumerable<ClienteResponseDto>))]
    public async Task<IActionResult> GetAll()
    {
        var result = await _clienteServices.GetAllClientes();
        return Ok(_mapper.Map<IEnumerable<ClienteResponse>, IEnumerable<ClienteResponseDto>>(result));
    }

    [HttpGet("{id}", Name = "GetById")]
    [ProducesDefaultResponseType(typeof(ClienteResponseDto))]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await _clienteServices.GetCliente(new ClienteGetRequest { Id = id });
        return Ok(_mapper.Map<ClienteResponseDto>(result));
    }

    [HttpPost]
    [ProducesDefaultResponseType(typeof(ClienteResponseDto))]
    public async Task<IActionResult> Create([FromBody] ClienteRequestDto request)
    {
        var result = await _clienteServices.CreateCliente(_mapper.Map<ClienteCreateCommand>(request));
        return CreatedAtRoute("GetById", new { id = result.Id.ToString() }, _mapper.Map<ClienteResponseDto>(result));
    }
}
