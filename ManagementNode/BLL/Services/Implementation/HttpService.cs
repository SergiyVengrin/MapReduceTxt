using BLL.Models;
using BLL.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace BLL.Services.Implementation
{
    public sealed class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task SendAsync(List<FileModel> files, string port) // Add return type   
        {
            try
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:{port}/api/Node/SaveFiles")
                {
                    Content = new StringContent(JsonSerializer.Serialize(files), Encoding.UTF8, "application/json")
                };

                var httpClient = _httpClientFactory.CreateClient();
                var httpResponse = await httpClient.SendAsync(httpRequest);
            }
            catch { throw; }
        }
    }
}
