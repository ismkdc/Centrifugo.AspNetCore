using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Centrifugo.AspNetCore.Abstractions;
using Centrifugo.AspNetCore.Extensions;
using Centrifugo.AspNetCore.Models.Abstraction;
using Centrifugo.AspNetCore.Models.Common;
using Centrifugo.AspNetCore.Models.Request;
using Centrifugo.AspNetCore.Models.Response;

namespace Centrifugo.AspNetCore.Implementations
{
    public class CentrifugoClient : ICentrifugoClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CentrifugoClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<Response<EmptyResult>> Publish(PublishParams parameters)
            => SendRequest<PublishParams, EmptyResult>(parameters);

        public Task<Response<EmptyResult>> Broadcast(BroadcastParams parameters)
            => SendRequest<BroadcastParams, EmptyResult>(parameters);

        public Task<Response<EmptyResult>> Subscribe(SubscribeParams parameters)
            => SendRequest<SubscribeParams, EmptyResult>(parameters);

        public Task<Response<EmptyResult>> UnSubscribe(UnSubscribeParams parameters)
            => SendRequest<UnSubscribeParams, EmptyResult>(parameters);

        public Task<Response<EmptyResult>> Disconnect(DisconnectParams parameters)
            => SendRequest<DisconnectParams, EmptyResult>(parameters);

        public Task<Response<EmptyResult>> Refresh(RefreshParams parameters)
            => SendRequest<RefreshParams, EmptyResult>(parameters);

        public Task<Response<PresenceResult>> Presence(PresenceParams parameters)
            => SendRequest<PresenceParams, PresenceResult>(parameters);

        public Task<Response<PresenceStatsResult>> PresenceStats(PresenceStatsParams parameters)
            => SendRequest<PresenceStatsParams, PresenceStatsResult>(parameters);

        public Task<Response<HistoryResult>> History(HistoryParams parameters)
            => SendRequest<HistoryParams, HistoryResult>(parameters);

        public Task<Response<EmptyResult>> HistoryRemove(HistoryRemoveParams parameters)
            => SendRequest<HistoryRemoveParams, EmptyResult>(parameters);

        public Task<Response<ChannelsResult>> Channels()
            => SendRequest<ChannelsParams, ChannelsResult>(new ChannelsParams());

        public Task<Response<InfoResult>> Info()
            => SendRequest<InfoParams, InfoResult>(new InfoParams());

        public async Task<Response<TRes>> SendRequest<TReq, TRes>(TReq req) where TReq : IRequestParams, new()
            where TRes : IResponseResult
        {
            var httpClient = _httpClientFactory.CreateClient(ServiceCollectionExtensions.NamedClientName);
            var body = new Request<TReq>(req);
            var result = await httpClient.PostAsJsonAsync("", body);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<Response<TRes>>();
        }
    }
}