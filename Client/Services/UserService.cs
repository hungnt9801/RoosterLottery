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
    internal class UserService
    {
        //private readonly HttpClient _client;
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7266/api/users";

        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        internal UserService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }
        
        //internal async Task<int> AddUserAsync(UserRequest user)
        //{
        //    JsonContent content = JsonContent.Create(user);
        //    //string uri = _client.BaseAddress + "api/users";
        //    HttpResponseMessage response = await _httpClient.PostAsync(content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string responseBody = await response.Content.ReadAsStringAsync();

        //        int ret = JsonSerializer.Deserialize<int>(responseBody, options);
        //        return ret;
        //    }
        //    else
        //    {
        //        throw new Exception($"Error: {response.StatusCode}");
        //    }
        //}

        public async Task AddUserAsync(UserRequest user)
        {
            string uri = _httpClient.BaseAddress + "/add-user";
            HttpResponseMessage response = await _httpClient.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to add user. Error: {errorMessage}");
            }
        }

        public async Task<UserResponse> GetUserByPhoneNumber(string phoneNumber)
        {
            string uri = _httpClient.BaseAddress + "/user-by-phonenumber?phoneNumber=" + phoneNumber;
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var user = JsonConvert.DeserializeObject<UserResponse>(await response.Content.ReadAsStringAsync());
                return user;
            }
            else
            {
                throw new Exception($"Failed to get user by phonenumber. Status code: {response.StatusCode}");
            }
        }

        public async Task<List<UserBetResponse>> GetUserBets(int userId)
        {
            string uri = _httpClient.BaseAddress + "/user-bets?userid=" + userId;
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                //List<UserBetResponse> userBets = await response.Content.ReadAsAsync<List<UserBetResponse>>();
                var userBets = JsonConvert.DeserializeObject<List<UserBetResponse>>(await response.Content.ReadAsStringAsync());
                return userBets;
            }
            else
            {
                throw new Exception($"Failed to get user bets. Status code: {response.StatusCode}");
            }
        }
    }
}
