using PlatformService.Models;

namespace PlatformService.Data
{
	public class PlatformRepo(AppDbContext context) : IPlatformRepo
	{
		private readonly AppDbContext _context = context;

		public void CreatePlatform(Platform platform)
		{
			ArgumentNullException.ThrowIfNull(platform);
			_context.Add(platform);
		}

		public IEnumerable<Platform> GetAllPlatforms() => [.. _context.Platforms];

		public Platform GetPlatformById(int id) => _context.Platforms.FirstOrDefault(e => e.Id == id);

		public bool SaveChanges() => (_context.SaveChanges() >= 0);
	}
}
