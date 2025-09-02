using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Turnos.API.DTOs;
using Turnos.Application.Abstractions.Services;
using Turnos.Application.DTOs.Input;

namespace Turnos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;
    private readonly IMapper _mapper;

    public ServiceController(IServiceService serviceService, IMapper mapper)
    {
        _serviceService = serviceService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateService(ServiceRequestDto dto)
    {
        var service = _mapper.Map<CreateServiceDto>(dto);
        await _serviceService.AddAsync(service);
        return Ok("Servicio creado con exito");
    }
}