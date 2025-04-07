using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlatformsController(IPlatformRepo repo, IMapper mapper) : ControllerBase
	{
		private readonly IMapper _mapper = mapper;
		private readonly IPlatformRepo _platformRepo = repo;

		[HttpGet]
		public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
		{
			Console.WriteLine("Getting Platforms");

			IEnumerable<Models.Platform> platformItems = _platformRepo.GetAllPlatforms();
			return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platformItems));
		}

		[HttpGet("{id}", Name = "GetPlatformById")]
		public ActionResult<PlatformReadDTO> GetPlatformById(int id)
		{
			Platform platformItem = _platformRepo.GetPlatformById(id);
			if (platformItem is not null)
			{
				return Ok(_mapper.Map<PlatformReadDTO>(platformItem));
			}
			return NotFound();
		}

		[HttpPost]
		public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO createDTO)
		{
			Platform platformModel = _mapper.Map<Platform>(createDTO);
			_platformRepo.CreatePlatform(platformModel);
			_platformRepo.SaveChanges();

			PlatformReadDTO platformReadDTO = _mapper.Map<PlatformReadDTO>(platformModel);

			return CreatedAtRoute(nameof(GetPlatformById), new { platformReadDTO.Id }, platformReadDTO);
		}
	}
}
