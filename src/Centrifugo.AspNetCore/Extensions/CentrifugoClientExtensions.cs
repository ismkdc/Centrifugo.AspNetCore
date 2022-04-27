using System.Threading.Tasks;
using Centrifugo.AspNetCore.Abstractions;
using Centrifugo.AspNetCore.Models.Common;
using Centrifugo.AspNetCore.Models.Request;
using ChannelsResponse = Centrifugo.AspNetCore.Models.Response.Channels;
using InfoResponse = Centrifugo.AspNetCore.Models.Response.Info;
using PresenceResponse = Centrifugo.AspNetCore.Models.Response.Presence;
using Presence_StatsResponse = Centrifugo.AspNetCore.Models.Response.Presence_Stats;
using HistoryResponse = Centrifugo.AspNetCore.Models.Response.History;
using EmptyResponse = Centrifugo.AspNetCore.Models.Response.Empty;

namespace Centrifugo.AspNetCore.Extensions
{
    public static class CentrifugoClientExtensions
    {
        /// <summary>
        ///     See <see cref="ICentrifugoClient.Publish" />.
        /// </summary>
        public static Task<Response<EmptyResponse>> PublishSimple(this ICentrifugoClient client, string channel,
            object data)
        {
            var request = new Publish
            {
                Channel = channel,
                Data = data
            };

            return client.Publish(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.Broadcast" />.
        /// </summary>
        public static Task<Response<EmptyResponse>> BroadcastSimple(this ICentrifugoClient client, object data,
            params string[] channels)
        {
            var request = new Broadcast
            {
                Data = data,
                Channels = channels
            };

            return client.Broadcast(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.Subscribe" />.
        /// </summary>
        public static Task<Response<EmptyResponse>> SubscribeSimple(this ICentrifugoClient client, string user,
            string channel)
        {
            var request = new Subscribe
            {
                User = user,
                Channel = channel
            };

            return client.Subscribe(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.Subscribe" />.
        /// </summary>
        public static Task<Response<EmptyResponse>> UnSubscribeSimple(this ICentrifugoClient client, string user,
            string channel)
        {
            var request = new UnSubscribe
            {
                User = user,
                Channel = channel
            };

            return client.UnSubscribe(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.Disconnect" />.
        /// </summary>
        public static Task<Response<EmptyResponse>> DisconnectSimple(this ICentrifugoClient client, string user)
        {
            var request = new Disconnect
            {
                User = user
            };

            return client.Disconnect(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.Refresh" />.
        /// </summary>
        public static Task<Response<EmptyResponse>> RefreshSimple(this ICentrifugoClient client, string user)
        {
            var request = new Refresh
            {
                User = user
            };

            return client.Refresh(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.Presence" />.
        /// </summary>
        public static Task<Response<PresenceResponse>> PresenceSimple(this ICentrifugoClient client, string channel)
        {
            var request = new Presence
            {
                Channel = channel
            };

            return client.Presence(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.Presence_Stats" />.
        /// </summary>
        public static Task<Response<Presence_StatsResponse>> Presence_StatsSimple(this ICentrifugoClient client,
            string channel)
        {
            var request = new Presence_Stats
            {
                Channel = channel
            };

            return client.Presence_Stats(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.History" />.
        /// </summary>
        public static Task<Response<HistoryResponse>> HistorySimple(this ICentrifugoClient client, string channel)
        {
            var request = new History
            {
                Channel = channel
            };

            return client.History(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.History_Remove" />.
        /// </summary>
        public static Task<Response<EmptyResponse>> History_RemoveSimple(this ICentrifugoClient client, string channel)
        {
            var request = new History_Remove
            {
                Channel = channel
            };

            return client.History_Remove(request);
        }
    }
}