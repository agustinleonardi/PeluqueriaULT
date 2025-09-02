using Turnos.Domain.Enums;

namespace Turnos.API.DTOs;

public class ServiceRequestDto
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int Duration { get; set; }
    public required TypeService TypeService { get; set; }

}