using Turnos.Domain.Enums;

namespace Turnos.Application.DTOs.Input;

public class CreateServiceDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public TypeService TypeService { get; set; }
    public int Duration { get; set; }
}
