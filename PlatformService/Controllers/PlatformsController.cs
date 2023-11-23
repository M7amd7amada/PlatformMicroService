using AutoMapper;
using AutoMapper.Configuration.Annotations;

using Microsoft.AspNetCore.Mvc;

using PlatformService.Data;
using PlatformService.Dtos;

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
    [Route("GetAll")]
    public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
    {
        Console.WriteLine("---> Getting All Platforms");
        var platforms = _repository.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }
}