using System;
using EaseVTU.Data;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace EaseVTU.Controllers
{
    public class ElectricityController
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public ElectricityController(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> CreatePayment(DiscoName discoName, decimal amount, int meterNumber, MeterType meterType)
        {
            var apiKey = _config["VTU:ApiKey"];
            var apiUrl = _config["VTU:ApiUrl"];

            var payload = new Dictionary<string, string>
            {
                {"disco_name", discoName.ToString() },
                {"amount", amount.ToString()},
                {"meter_number", meterNumber.ToString()},
                {"meter_type", meterType.ToString() }
            };

            var content = new FormUrlEncodedContent(payload);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var response = await _httpClient.PostAsync(apiUrl + "billpayment/", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<VTUApiResponse>(responseString);
                return JsonConvert.SerializeObject(new ElectricityResponse
                {
                    Success = true,
                    Message = "Electricity recharged successfully.",
                    ReferenceNumber = responseData.ReferenceNumber
                });
            }
            else
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<VTUApiError>(responseString);
                return JsonConvert.SerializeObject(new ElectricityResponse
                {
                    Success = false,
                    Message = responseData.Message
                });
            }

        }
    }
}

