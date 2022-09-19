using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoTWBlaSe
{
    public class GoTWHttp
    {
        private readonly IHttpClientFactory _httpClient;

        public GoTWHttp(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<CommandersDTO> GetCommanderSkills(string skill)
        {
            CommandersDTO commanders = new CommandersDTO();

            var request = new HttpRequestMessage(HttpMethod.Get,Helper.apiAddress);

            var client = _httpClient.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                commanders = await JsonSerializer.DeserializeAsync<CommandersDTO>(responseStream).ConfigureAwait(false);
            }

            return commanders;
        }
    }
}
