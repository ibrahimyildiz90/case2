using MicroServices.Services.Obilet.Application.Dtos;
using MicroServices.Services.Obilet.Application.Dtos.Bus;
using MicroServices.Services.Obilet.Application.Dtos.Session;
using MicroServices.Services.Obilet.Application.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MicroServices.Services.Obilet.Application.Services
{
    public class IntegrationService : IIntegrationService
    {
        private readonly string apiUrl;
        private readonly string apiClientToken;
        private readonly HttpClient _client;

        public IntegrationService(IHttpClientFactory httpClientFactory, AppSettings appSettings)
        {
            _client = httpClientFactory.CreateClient();
            apiUrl = appSettings.ApiUrl;
            apiClientToken = appSettings.ApiClientToken;
        }

        private void AddAuthorization()
        {
            var auth = string.Concat("Basic", " ", apiClientToken);

            if (_client.DefaultRequestHeaders.Contains("Authorization"))
            {
                if (_client.DefaultRequestHeaders.Authorization.ToString() != auth)
                {
                    _client.DefaultRequestHeaders.Remove("Authorization");
                    _client.DefaultRequestHeaders.Add("Authorization", auth);
                }
            }
            else
            {
                _client.DefaultRequestHeaders.Add("Authorization", auth);
            }
        }

        private StringContent CreateStringContent(object _object)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
            };

            var content = new StringContent(JsonConvert.SerializeObject(_object, jsonSerializerSettings), Encoding.UTF8, "application/json");

            return content;
        }

        public async Task<Response<List<BusJourneyDto>>> GetBusJourneys(Request<BusJourneyReqDto> request)
        {
            AddAuthorization();

            var url = $"{apiUrl}journey/getbusjourneys";

            var content = CreateStringContent(request);

            var response = await _client.PostAsync(url, content);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Status Code:{response.StatusCode} ReasonPhrase:{response.ReasonPhrase}");

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Response<List<BusJourneyDto>>>(responseString);

            return result;
        }

        public async Task<Response<List<BusLocationDto>>> GetBusLocations(Request<string> request)
        {
            AddAuthorization();


            var url = $"{apiUrl}location/getbuslocations";

            var content = CreateStringContent(request);

            var response = await _client.PostAsync(url, content);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Status Code:{response.StatusCode} ReasonPhrase:{response.ReasonPhrase}");

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Response<List<BusLocationDto>>>(responseString);

            return result;
        }

        public async Task<Response<SessionDto>> GetSession(SessionReqDto sessionRequest)
        {
            AddAuthorization();

            var url = $"{apiUrl}client/getsession";

            var content = CreateStringContent(sessionRequest);

            var response = await _client.PostAsync(url, content);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Status Code:{response.StatusCode} ReasonPhrase:{response.ReasonPhrase}");

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Response<SessionDto>>(responseString);

            return result;
        }
    }
}
