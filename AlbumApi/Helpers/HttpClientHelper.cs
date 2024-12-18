using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlbumApi.Helpers
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HttpClientHelper(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetAndDeserializeAsync<T>(string requestUri)
        {
            var client = httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }
    }
}
