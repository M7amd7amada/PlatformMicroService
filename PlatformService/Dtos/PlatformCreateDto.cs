using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos;

public record PlatformCreateDto
{
    [Required]
    public decimal Cost { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Publisher { get; set; }
}