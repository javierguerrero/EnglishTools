using Clients.BackOffice.Proxies.Catalog.Commands;
using Clients.BackOffice.Proxies.Catalog.DTOs;
using Clients.BackOffice.Proxies.Common;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Clients.BackOffice.Proxies.Catalog
{
    public interface ICatalogProxy
    {
        Task<DataCollection<LessonOverviewDto>> GetLessonOverviewsAsync(int page, int take);

        Task<LessonDto> GetLessonAsync(int id);

        Task CrateLessonAsync(LessonCreateCommand lesson);
    }

    public class CatalogProxy : ICatalogProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public CatalogProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<DataCollection<LessonOverviewDto>> GetLessonOverviewsAsync(int page, int take)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}lessons?page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<LessonOverviewDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<LessonDto> GetLessonAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}lessons/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<LessonDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task CrateLessonAsync(LessonCreateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}lessons", content);
            request.EnsureSuccessStatusCode();
        }
    }
}