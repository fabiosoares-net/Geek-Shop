using System.Net.Http.Headers;
using System.Text.Json;

namespace Geek.Web.Helper.Util
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");

        public static async Task<T> GetContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode) 
                throw new ApplicationException($"Something went wrong calling the API: " + $"{response.ReasonPhrase}");

            var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;

            return httpClient.PostAsync(url, content);
        }

        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            return httpClient.PutAsync(url, content);
        }
    }
}
