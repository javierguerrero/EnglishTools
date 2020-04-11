using Api.Gateway.Models;
using Api.Gateway.Models.Catalog.Commands;
using Api.Gateway.Models.Catalog.DTOs;
using Api.Gateway.Proxy;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.Proxies
{
    public interface ICatalogProxy
    {
        Task<DataCollection<LessonDto>> GetLessonsAsync(int page, int take);

        Task<LessonDto> GetLessonAsync(int id);
        Task CreateLessonAsync(LessonCreateCommand command);
    }

    public class CatalogProxy : ICatalogProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public CatalogProxy(
            HttpClient httpClient,
            IOptions<ApiUrls> apiUrls,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task<DataCollection<LessonDto>> GetLessonsAsync(int page, int take)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.CatalogUrl}lessons?page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<LessonDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<LessonDto> GetLessonAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.CatalogUrl}lessons/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<LessonDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task CreateLessonAsync(LessonCreateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrls.CatalogUrl}lessons", content);
            request.EnsureSuccessStatusCode();
        }
    }
}