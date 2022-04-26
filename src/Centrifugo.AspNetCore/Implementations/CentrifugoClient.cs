using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Centrifugo.AspNetCore.Abstractions;
using Centrifugo.AspNetCore.Extensions;
using Centrifugo.AspNetCore.Models.Common;
using Centrifugo.AspNetCore.Models.Request;
using EmptyResponse = Centrifugo.AspNetCore.Models.Response.Empty;
using ChannelsResponse = Centrifugo.AspNetCore.Models.Response.Channels;
using InfoResponse = Centrifugo.AspNetCore.Models.Response.Info;

namespace Centrifugo.AspNetCore.Implementations
{
    public class CentrifugoClient : ICentrifugoClient
    {
        private readonly HttpClient _httpClient;

        public CentrifugoClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ServiceCollectionExtensions.NamedClientName);
        }

        public async Task<Response<EmptyResponse>> Publish(Publish req)
        {
            var result = await SendRequest(new Request<Publish>(req));

            return await result.ReadFromJsonAsync<Response<EmptyResponse>>();
        }

        public async Task<Response<EmptyResponse>> Broadcast(Broadcast req)
        {
            var result = await SendRequest(new Request<Broadcast>(req));

            return await result.ReadFromJsonAsync<Response<EmptyResponse>>();
        }

        public async Task<Response<ChannelsResponse>> Channels()
        {
            var result = await SendRequest(new Request<Channels>());

            return await result.ReadFromJsonAsync<Response<ChannelsResponse>>();
        }

        public async Task<Response<InfoResponse>> Info()
        {
            var result = await SendRequest(new Request<Info>());

            return await result.ReadFromJsonAsync<Response<InfoResponse>>();
        }

        private async Task<HttpContent> SendRequest<T>(T req)
        {
            var result = await _httpClient.PostAsJsonAsync("", req);

            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadAsStringAsync();

            return result.Content;
        }
    }
}