using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;
using System.Threading.Tasks;

namespace PlatformService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlatformsController(IPlatformRepo repo, IMapper mapper, ICommandDataClient commandDataClient) : ControllerBase
	{
		private readonly IMapper _mapper = mapper;
		private readonly IPlatformRepo _platformRepo = repo;
		private readonly ICommandDataClient _commandDataClient = commandDataClient;

		[HttpGet]
		public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
		{
			Console.WriteLine("Getting Platforms");

			IEnumerable<Platform> platformItems = _platformRepo.GetAllPlatforms();
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
		public async Task<ActionResult<PlatformReadDTO>> CreatePlatform(PlatformCreateDTO createDTO)
		{
			Platform platformModel = _mapper.Map<Platform>(createDTO);
			_platformRepo.CreatePlatform(platformModel);
			_platformRepo.SaveChanges();

			PlatformReadDTO platformReadDTO = _mapper.Map<PlatformReadDTO>(platformModel);

			try
			{
				await _commandDataClient.SendPlatformToCommand(platformReadDTO);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Could not send synchronously: {ex.Message}");
			}

			return CreatedAtRoute(nameof(GetPlatformById), new { platformReadDTO.Id }, platformReadDTO);
		}
	}
}
