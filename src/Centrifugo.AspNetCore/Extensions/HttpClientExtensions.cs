using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Centrifugo.AspNetCore.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> NewtonsoftPostAsJsonAsync<T>(this HttpClient client, string requestUrl,
            T obj)
        {
            var stringContent = new StringContent
            (
                JsonConvert.SerializeObject(obj),
                Encoding.UTF8, "application/json"
            );

            return await client.PostAsync(requestUrl, stringContent);
        }
    }
}