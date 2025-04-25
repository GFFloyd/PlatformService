using PlatformService.DTOs;
using System.Text;
using System.Text.Json;

namespace PlatformService.SyncDataServices.Http
{
	public class HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration) : ICommandDataClient
	{
		private readonly HttpClient _httpClient = httpClient;
		private readonly IConfiguration _configuration = configuration;

		public async Task SendPlatformToCommand(PlatformReadDTO readDTO)
		{
			var httpContent = new StringContent(
				JsonSerializer.Serialize(readDTO),
				Encoding.UTF8,
				"application/json"
				);

			var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);

			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("Sync POST to CommandService was OK");
			}
			else
			{
				Console.WriteLine("Sync POST to CommandService was not OK");
			}
		}
	}
}
