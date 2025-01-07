using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Crowdfunding.Share.Utility.Http
{
    internal class HttpRequest : IHttpRequest, IDisposable
    {
        private const string MediaTypeJson = "application/json";
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(90);
        private string _baseUrl = "";
        private HttpClient? _httpClient;
        private HttpClientHandler? _httpClientHandler;
        public void Dispose()
        {
            _httpClientHandler?.Dispose();
            _httpClient?.Dispose();
        }
        public string BaseUrl
        {

            set => _baseUrl = NormalizeBaseUrl(value);
        }

        public string Token { set; get; } = "";

        private static string NormalizeBaseUrl(string url)
        {
            return url.EndsWith("/") ? url : url + "/";
        }

        private void CreateHttpClient()
        {
            _httpClientHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            };

            _httpClient = new HttpClient(_httpClientHandler, false)
            {
                Timeout = _timeout
            };

            if (!string.IsNullOrWhiteSpace(_baseUrl))
            {
                _httpClient.BaseAddress = new Uri(_baseUrl);
            }

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeJson));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        }

        private void EnsureHttpClientCreated()
        {
            if (_httpClient == null)
            {
                CreateHttpClient();
            }

            if (_httpClient.BaseAddress.ToString() != _baseUrl)
            {
                CreateHttpClient();
            }
        }

        private static string ConvertToJsonString(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            string reqData = JsonConvert.SerializeObject(obj);

            return reqData;
        }

        public async Task<string> GetAsync(string url)
        {
            EnsureHttpClientCreated();

            using (HttpResponseMessage response = await _httpClient!.GetAsync(url))
            {
                if (response.StatusCode == HttpStatusCode.GatewayTimeout)
                {
                    throw new HttpException(HttpStatusCode.GatewayTimeout, "Drchrono Crash");
                }

                response.EnsureSuccessStatusCode();
                string test = await response.Content.ReadAsStringAsync();
                return test;
            }
        }

        public async Task<TResult> GetAsync<TResult>(string url, Dictionary<string, string>? urlParams = null)
        {
            url = AttachUrlParam(url, urlParams);
            string strResponse1 = await GetAsync(url);


            return JsonConvert.DeserializeObject<TResult>(strResponse1, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            })!;
        }


        public async Task<string> PostAsync(string url, object input)
        {
            EnsureHttpClientCreated();

            using (StringContent requestContent = new StringContent(ConvertToJsonString(input), Encoding.UTF8, MediaTypeJson))
            {
                using (HttpResponseMessage response = await _httpClient!.PostAsync(url, requestContent))
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new HttpException(response.StatusCode, "Server Crash");
                    }

                    string test = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(test);
                    }

                    //response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }


        public async Task<TResult> PostAsync<TResult>(string url, object input, Dictionary<string, string>? urlParams = null)
        {
            if (urlParams != null)
            {
                url = AttachUrlParam(url, urlParams);
            }

            string strResponse = await PostAsync(url, input);


            return JsonConvert.DeserializeObject<TResult>(strResponse, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            })!;
        }
        public string AttachUrlParam(string url, Dictionary<string, string> urlParams)
        {
            #region Add url parameters

            if (urlParams is not null)
            {
                url += "?";

                foreach (string key in urlParams.Keys)
                {
                    url += $"{key}={urlParams[key]}&";
                }
            }

            #endregion

            return url;
        }

        public async Task<TResult> PostAsync<TResult>(string url, MultipartFormDataContent input, Dictionary<string, string>? urlParams = null)
        {
            if (urlParams != null)
            {
                url = AttachUrlParam(url, urlParams);
            }

            EnsureHttpClientCreated();


            using (HttpResponseMessage response = await _httpClient!.PostAsync(url, input))
            {
                if (response.StatusCode == HttpStatusCode.GatewayTimeout)
                {
                    throw new HttpException(HttpStatusCode.GatewayTimeout, "Drchrono Crash");
                }
                string test = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<TResult>(await response!.Content.ReadAsStringAsync());
            }
        }

        public async Task<TResult> PutAsync<TResult>(string url, object input, Dictionary<string, string>? urlParams = null)
        {
            if (urlParams != null)
            {
                url = AttachUrlParam(url, urlParams);
            }
            string strResponse = await PutAsync(url, input);


            return JsonConvert.DeserializeObject<TResult>(strResponse, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            })!;
        }

        public async Task<string> PutAsync(string url, object input)
        {
            return await PutAsync(url, new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, MediaTypeJson));
        }

        public async Task<string> DeleteAsync(string url)
        {
            EnsureHttpClientCreated();

            using (HttpResponseMessage response = await _httpClient.DeleteAsync(url))
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpException(response.StatusCode, "Server Crash");
                }
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

    }
}
