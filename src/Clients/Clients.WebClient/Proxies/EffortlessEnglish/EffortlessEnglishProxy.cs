using Clients.WebClient.Proxies.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Clients.WebClient.Proxies.EffortlessEnglish
{
    public interface IEffortlessEnglishProxy
    {
        Task<DataCollection<LevelDto>> GetAllAsync(int page, int take);
    }

    public class EffortlessEnglishProxy : IEffortlessEnglishProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public EffortlessEnglishProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<DataCollection<LevelDto>> GetAllAsync(int page, int take)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}effortless-english/levels?page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<LevelDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
