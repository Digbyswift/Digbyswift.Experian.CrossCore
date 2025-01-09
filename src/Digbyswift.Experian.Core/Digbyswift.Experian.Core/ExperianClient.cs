using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Digbyswift.Experian.Core.AmlRequestObjects;
using Digbyswift.Experian.Core.Configuration;
using Digbyswift.Experian.Core.Extensions;
using Serilog;

namespace Digbyswift.Experian.Core
{
    /// <summary>
    /// An accessor class to ensure that the ServiceClient is created and disposed per
    /// request. This way, the ServiceClient only exists when it is required.
    /// </summary>
#if NETFRAMEWORK
    public sealed class ExperianClient : IDisposable
    {
        private readonly HttpClient _httpClient;
#else
    public sealed class ExperianClient
    {
        private readonly HttpClient _httpClient;
#endif
        private readonly string _authTokenBodyJson;
        private readonly ExperianCrossCoreConfig _config;
        private readonly Endpoints _endpoints;

#if NETFRAMEWORK
        public ExperianClient(ExperianCrossCoreConfig config)
        {
            _config = config;
            _httpClient = new();
            _endpoints = new Endpoints();
            _authTokenBodyJson = new AccessTokenRequestBody()
            {
                Username = config.Username,
                Password = config.Password,
                ClientId = config.ClientId,
                ClientSecret = config.ClientSecret
            }.Serialize();

            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
        }
#else
        public ExperianClient(HttpClient httpClient, ExperianCrossCoreConfig config, Endpoints endpoints)
        {
            _config = config;
            _endpoints = endpoints;
            _authTokenBodyJson = new AccessTokenRequestBody
            {
                Username = config.Username,
                Password = config.Password,
                ClientId = config.ClientId,
                ClientSecret = config.ClientSecret
            }.Serialize();

            _httpClient = httpClient;
            _httpClient.Timeout = new TimeSpan(0, 0, 10);
            _httpClient.DefaultRequestHeaders.Clear();
        }
#endif

#if NETFRAMEWORK
        public async Task<HttpResponseMessage> GetAsync(string url)
#else
        public async Task<HttpResponseMessage?> GetAsync(string url)
#endif
        {
            using var requestMessage = await CreateRequestMessageAsync(url);
            if (requestMessage == null)
            {
                Log.Warning("Unable to get #experian");
                return null;
            }

            return await _httpClient.SendAsync(requestMessage);
        }

#if NETFRAMEWORK
        public async Task<T> PostAsync<T>(string url, RequestPayload payload) where T : class
#else
        public async Task<T?> PostAsync<T>(string url, RequestPayload payload) where T : class
#endif
        {
            var json = new AmlRequest(_config.ClientId, _config.TenantId)
            {
                Payload = payload
            }.Serialize();

            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

            using var requestMessage = await CreateRequestMessageAsync(url, HttpMethod.Post, requestContent);
            if (requestMessage == null)
            {
                Log.Warning("Unable to post: {json} #experian", json);
                return null;
            }

            var response = await _httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponseContent = await response.Content.ReadAsStringAsync();
                Log.Warning("Failed posting: {error} #experian", errorResponseContent);

                return null;
            }

            using var responseContent = await response.Content.ReadAsStreamAsync();
            var responseObject = await responseContent.DeserializeAsync<T>();

            return responseObject;
        }

#if NETFRAMEWORK
        public void Dispose()
        {
            _httpClient.Dispose();
        }
#else
#endif

#if NETFRAMEWORK
        private async Task<HttpRequestMessage> CreateRequestMessageAsync(string url, HttpMethod method = null, HttpContent content = null)
#else
        private async Task<HttpRequestMessage?> CreateRequestMessageAsync(string url, HttpMethod? method = null, HttpContent? content = null)
#endif
        {
            var accessToken = await GetTokenAsync();
            if (String.IsNullOrWhiteSpace(accessToken))
                return null;

            var request = new HttpRequestMessage(method ?? HttpMethod.Get, url);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (content != null)
            {
                request.Content = content;
            }

            return request;
        }

#if NETFRAMEWORK
        private async Task<string> GetTokenAsync()
#else
        private async Task<string?> GetTokenAsync()
#endif
        {
            var requestContent = new StringContent(_authTokenBodyJson, Encoding.UTF8, "application/json");
            requestContent.Headers.Add("X-User-Domain", _config.AuthDomain);

            using var response = await _httpClient.PostAsync(_endpoints.AuthTokenUrl, requestContent);
            if (!response.IsSuccessStatusCode)
            {
                var errorResponseContent = await response.Content.ReadAsStringAsync();
                Log.Warning("Failed getting auth token: {error} #experian", errorResponseContent);

                return null;
            }

            using var responseContent = await response.Content.ReadAsStreamAsync();
            var responseObject = await responseContent.DeserializeAsync<AccessTokenResponse>();

            return responseObject.AccessToken;
        }
    }
}
