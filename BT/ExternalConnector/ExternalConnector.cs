using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BT.ExternalConnector
{
    public class ExternalConnector
    {
        private readonly HttpClient _httpClient;
        private ILogger<ExternalConnector> _logger;

        public ExternalConnector(
            HttpClient httpClient, 
            ILogger<ExternalConnector> logger)
        {
            _httpClient = httpClient ?? throw new Exception(nameof(httpClient));
            _logger = logger ?? throw new Exception(nameof(logger));
        }

        public async Task<List<T>> GetAccountsAsync<T>() where T : class
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44325/api/Accounts");

            using var response = await _httpClient.SendAsync(request, CancellationToken.None);
            try
            {
                response.EnsureSuccessStatusCode();
                
                return JsonConvert.DeserializeObject<List<T>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.ToString());
                throw new ArgumentException(exp.ToString());
            }
        }

        public async Task<T> GetSingleAccountByIdAsync<T>(int accountId) where T : class
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44325/api/Accounts/account/{accountId}");

            using var response = await _httpClient.SendAsync(request, CancellationToken.None);
            try
            {
                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.ToString());
                throw new ArgumentException(exp.ToString());
            }
        }
    }
}
