using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo _repository;
    private readonly IMapper _mapper;

    public PlatformsController(IPlatformRepo repository, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(repository);
        ArgumentNullException.ThrowIfNull(mapper);

        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("GetAllPlatforms")]
    public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
    {
        Console.WriteLine("---> Getting All Platforms");
        IEnumerable<Platform> platforms = _repository.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }

    [HttpPost]
    [Route("CreatePlatform")]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
        var platform = _mapper.Map<Platform>(platformCreateDto);
        _repository.CreatePlatform(platform);
        _repository.SaveChanges();
        var platformReadDto = _mapper.Map<PlatformReadDto>(platform);
        return CreatedAtRoute(
                nameof(GetPlatformById),
                new { Id = platformReadDto.Id },
                platformReadDto);
    }

    [HttpGet]
    [Route("GetPlatform", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        Console.WriteLine($"---> Get Platform {id}");
        try
        {
            var platform = _repository.GetPlatformById(id);
            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }
        catch (ArgumentNullException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}