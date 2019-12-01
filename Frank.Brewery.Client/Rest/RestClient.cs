using Frank.Brewery.Client.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Frank.Brewery.Client.Rest
{
    public class RestClient<T> : IRestClient<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RestClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetAsync(string url)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var response = await client.GetStringAsync(url);
                return JsonSerializer.Deserialize<T>(response);
            }
        }

        public async Task<IEnumerable<T>> GetManyAsync(string url)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var response = await client.GetStringAsync(url);
                return JsonSerializer.Deserialize<IEnumerable<T>>(response);
            }
        }

        public async Task<T> PostAsync(string url, object body)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var response = await client.PostAsync(url, body.ToHttpContent());
                if (response.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
                return default;
            }
        }

        public async Task<T> PutAsync(string url, object body)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var response = await client.PutAsync(new Uri(url), body.ToHttpContent());
                if (response.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
                return default;
            }
        }

        public async Task<T> DeleteAsync(string url)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var response = await client.DeleteAsync(url);
                return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
