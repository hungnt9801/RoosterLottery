using System.Net.Http;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client.Models;
using Newtonsoft.Json;
using Shared.Requests;
using Shared.Responses;
using static System.Windows.Forms.Design.AxImporter;

namespace Client.Services
{
    internal class BetService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7266/api/bets";

        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        internal BetService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        public async Task AddBetAsync(BetRequest bet)
        {
            string uri = _httpClient.BaseAddress + "/add-bet";
            HttpResponseMessage response = await _httpClient.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(bet), Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to add bet. Error: {errorMessage}");
            }
        }
    }
}
