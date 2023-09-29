using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace Portfolio.Business.Services.Github
{
    public class GithubApiService : IGithubApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GithubApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<short> GetRepoCountAsync(string username)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri("https://api.github.com/");
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("AppName", "1.0"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"users/{username}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var repoCount = short.Parse(JObject.Parse(content)["public_repos"].ToString());
                return repoCount;
            }
            catch (HttpRequestException)
            {
                // Hata yönetimi burada yapılabilir
                return -1;
            }
        }
    }
}