namespace PlatformService.Dtos;

public record PlatformReadDto
{
    public int Id { get; set; }
    public decimal Cost { get; set; }
    public required string Name { get; set; }
    public required string Publisher { get; set; }
}