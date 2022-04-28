using System.Threading.Tasks;
using Centrifugo.AspNetCore.Abstractions;
using Centrifugo.AspNetCore.Models.Common;
using Centrifugo.AspNetCore.Models.Request;
using Centrifugo.AspNetCore.Models.Response;

namespace Centrifugo.AspNetCore.Extensions
{
    public static class CentrifugoClientExtensions
    {
        /// <summary>
        ///     See <see cref="ICentrifugoClient.Publish" />.
        /// </summary>
        public static Task<Response<EmptyResult>> Publish(this ICentrifugoClient client,
            object data, string channel)
        {
            var request = new PublishParams
            {
                Channel = channel,
                Data = data
            };

            return client.Publish(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.Broadcast" />.
        /// </summary>
        public static Task<Response<EmptyResult>> Broadcast(this ICentrifugoClient client, object data,
            params string[] channels)
        {
            var request = new BroadcastParams
            {
                Data = data,
                Channels = channels
            };

            return client.Broadcast(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.Subscribe" />.
        /// </summary>
        public static Task<Response<EmptyResult>> Subscribe(this ICentrifugoClient client, string user,
            string channel)
        {
            var request = new SubscribeParams
            {
                User = user,
                Channel = channel
            };

            return client.Subscribe(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.Subscribe" />.
        /// </summary>
        public static Task<Response<EmptyResult>> UnSubscribe(this ICentrifugoClient client, string user,
            string channel)
        {
            var request = new UnSubscribeParams
            {
                User = user,
                Channel = channel
            };

            return client.UnSubscribe(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.Disconnect" />.
        /// </summary>
        public static Task<Response<EmptyResult>> Disconnect(this ICentrifugoClient client, string user)
        {
            var request = new DisconnectParams
            {
                User = user
            };

            return client.Disconnect(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.Refresh" />.
        /// </summary>
        public static Task<Response<EmptyResult>> Refresh(this ICentrifugoClient client, string user)
        {
            var request = new RefreshParams
            {
                User = user
            };

            return client.Refresh(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.Presence" />.
        /// </summary>
        public static Task<Response<PresenceResult>> Presence(this ICentrifugoClient client, string channel)
        {
            var request = new PresenceParams
            {
                ChannelParams = channel
            };

            return client.Presence(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.PresenceStats" />.
        /// </summary>
        public static Task<Response<Models.Response.PresenceStatsResult>> PresenceStats(this ICentrifugoClient client,
            string channel)
        {
            var request = new PresenceStatsParams
            {
                Channel = channel
            };

            return client.PresenceStats(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.History" />.
        /// </summary>
        public static Task<Response<HistoryResult>> History(this ICentrifugoClient client, string channel)
        {
            var request = new HistoryParams
            {
                Channel = channel
            };

            return client.History(request);
        }

        /// <summary>
        ///     See <see cref="ICentrifugoClient.HistoryRemove" />.
        /// </summary>
        public static Task<Response<EmptyResult>> HistoryRemove(this ICentrifugoClient client, string channel)
        {
            var request = new HistoryRemoveParams
            {
                Channel = channel
            };

            return client.HistoryRemove(request);
        }
    }
}