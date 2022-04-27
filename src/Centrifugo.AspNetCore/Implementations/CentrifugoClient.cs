using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Centrifugo.AspNetCore.Abstractions;
using Centrifugo.AspNetCore.Extensions;
using Centrifugo.AspNetCore.Models.Common;
using Centrifugo.AspNetCore.Models.Request;
using ChannelsResponse = Centrifugo.AspNetCore.Models.Response.Channels;
using InfoResponse = Centrifugo.AspNetCore.Models.Response.Info;
using PresenceResponse = Centrifugo.AspNetCore.Models.Response.Presence;
using Presence_StatsResponse = Centrifugo.AspNetCore.Models.Response.Presence_Stats;
using HistoryResponse = Centrifugo.AspNetCore.Models.Response.History;
using EmptyResponse = Centrifugo.AspNetCore.Models.Response.Empty;

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

        public async Task<Response<EmptyResponse>> Subscribe(Subscribe req)
        {
            var result = await SendRequest(new Request<Subscribe>(req));

            return await result.ReadFromJsonAsync<Response<EmptyResponse>>();
        }

        public async Task<Response<EmptyResponse>> UnSubscribe(UnSubscribe req)
        {
            var result = await SendRequest(new Request<UnSubscribe>(req));

            return await result.ReadFromJsonAsync<Response<EmptyResponse>>();
        }

        public async Task<Response<EmptyResponse>> Disconnect(Disconnect req)
        {
            var result = await SendRequest(new Request<Disconnect>(req));

            return await result.ReadFromJsonAsync<Response<EmptyResponse>>();
        }

        public async Task<Response<EmptyResponse>> Refresh(Refresh req)
        {
            var result = await SendRequest(new Request<Refresh>(req));

            return await result.ReadFromJsonAsync<Response<EmptyResponse>>();
        }

        public async Task<Response<PresenceResponse>> Presence(Presence req)
        {
            var result = await SendRequest(new Request<Presence>(req));

            return await result.ReadFromJsonAsync<Response<PresenceResponse>>();
        }

        public async Task<Response<Presence_StatsResponse>> Presence_Stats(Presence_Stats req)
        {
            var result = await SendRequest(new Request<Presence_Stats>(req));

            return await result.ReadFromJsonAsync<Response<Presence_StatsResponse>>();
        }

        public async Task<Response<HistoryResponse>> History(History req)
        {
            var result = await SendRequest(new Request<History>(req));

            return await result.ReadFromJsonAsync<Response<HistoryResponse>>();
        }

        public async Task<Response<EmptyResponse>> History_Remove(History_Remove req)
        {
            var result = await SendRequest(new Request<History_Remove>(req));

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

            return result.Content;
        }
    }
}