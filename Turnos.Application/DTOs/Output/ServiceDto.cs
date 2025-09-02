namespace Turnos.Application.DTOs.Output
{
    public class ServiceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }
    }
}