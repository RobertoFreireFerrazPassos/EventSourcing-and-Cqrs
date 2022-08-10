using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Kitchen.Client.Base
{
    public class ClientBase
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger<ClientBase> _logger;

        public ClientBase(
            HttpClient httpClient, 
            ILogger<ClientBase> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<T> Get<T>(Uri uri)
        {
            try
            {
                var responseString = await _httpClient.GetStringAsync(uri);

                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);

                return default(T);
            }
        }

        public async Task<V> Post<T,V>(Uri uri, T request)
        {
            try
            {
                var contentAsString = new StringContent(JsonConvert.SerializeObject(request));

                var response = await _httpClient.PostAsync(uri, contentAsString);

                var resultAsString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<V>(resultAsString);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);

                return default(V);
            }
        }
    }
}
