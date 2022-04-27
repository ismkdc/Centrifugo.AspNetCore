using System.Threading.Tasks;
using Centrifugo.AspNetCore.Models.Common;
using Centrifugo.AspNetCore.Models.Request;
using ChannelsResponse = Centrifugo.AspNetCore.Models.Response.Channels;
using InfoResponse = Centrifugo.AspNetCore.Models.Response.Info;
using PresenceResponse = Centrifugo.AspNetCore.Models.Response.Presence;
using Presence_StatsResponse = Centrifugo.AspNetCore.Models.Response.Presence_Stats;
using HistoryResponse = Centrifugo.AspNetCore.Models.Response.History;
using EmptyResponse = Centrifugo.AspNetCore.Models.Response.Empty;


namespace Centrifugo.AspNetCore.Abstractions
{
    public interface ICentrifugoClient
    {
        /// <summary>
        ///     Publish command allows publishing data into a channel.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<Response<EmptyResponse>> Publish(Publish req);

        /// <summary>
        ///     Similar to publish but allows to send the same data into many channels.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<Response<EmptyResponse>> Broadcast(Broadcast req);

        /// <summary>
        ///     Allows subscribing user to a channel.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<Response<EmptyResponse>> Subscribe(Subscribe req);

        /// <summary>
        ///     Allows unsubscribing user from a channel.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<Response<EmptyResponse>> UnSubscribe(UnSubscribe req);

        /// <summary>
        ///     Allows disconnecting a user by ID.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<Response<EmptyResponse>> Disconnect(Disconnect req);

        /// <summary>
        ///     Allows refreshing user connection (mostly useful when unidirectional transports are used).
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<Response<EmptyResponse>> Refresh(Refresh req);

        /// <summary>
        ///     (Presence in channels is not enabled by default) Allows getting channel online presence information.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<Response<PresenceResponse>> Presence(Presence req);

        /// <summary>
        ///     (Presence in channels is not enabled by default) Allows getting short channel presence information - number of
        ///     clients and number of unique users (based on user ID).
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<Response<Presence_StatsResponse>> Presence_Stats(Presence_Stats req);

        /// <summary>
        ///     (History in channels is not enabled by default) Allows getting channel history information (list of last messages
        ///     published into the channel)
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<Response<HistoryResponse>> History(History req);

        /// <summary>
        ///     (History in channels is not enabled by default) Allows removing publications in channel history. Current top stream
        ///     position meta data kept untouched to avoid client disconnects due to insufficient state.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<Response<EmptyResponse>> History_Remove(History_Remove req);

        /// <summary>
        ///     Return active channels (with one or more active subscribers in it).
        /// </summary>
        /// <returns></returns>
        public Task<Response<ChannelsResponse>> Channels();

        /// <summary>
        ///     Allows getting information about running Centrifugo nodes.
        /// </summary>
        /// <returns></returns>
        public Task<Response<InfoResponse>> Info();
    }
}