using System.Threading.Tasks;
using Centrifugo.AspNetCore.Models.Common;
using Centrifugo.AspNetCore.Models.Request;
using Centrifugo.AspNetCore.Models.Response;


namespace Centrifugo.AspNetCore.Abstractions
{
    public interface ICentrifugoClient
    {
        /// <summary>
        ///     Publish command allows publishing data into a channel.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<Response<EmptyResult>> Publish(PublishParams parameters);

        /// <summary>
        ///     Similar to publish but allows to send the same data into many channels.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<Response<EmptyResult>> Broadcast(BroadcastParams parameters);

        /// <summary>
        ///     Allows subscribing user to a channel.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<Response<EmptyResult>> Subscribe(SubscribeParams parameters);

        /// <summary>
        ///     Allows unsubscribing user from a channel.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<Response<EmptyResult>> UnSubscribe(UnSubscribeParams parameters);

        /// <summary>
        ///     Allows disconnecting a user by ID.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<Response<EmptyResult>> Disconnect(DisconnectParams parameters);

        /// <summary>
        ///     Allows refreshing user connection (mostly useful when unidirectional transports are used).
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<Response<EmptyResult>> Refresh(RefreshParams parameters);

        /// <summary>
        ///     (Presence in channels is not enabled by default) Allows getting channel online presence information.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<Response<PresenceResult>> Presence(PresenceParams parameters);

        /// <summary>
        ///     (Presence in channels is not enabled by default) Allows getting short channel presence information - number of
        ///     clients and number of unique users (based on user ID).
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<Response<Models.Response.PresenceStatsResult>> PresenceStats(PresenceStatsParams parameters);

        /// <summary>
        ///     (History in channels is not enabled by default) Allows getting channel history information (list of last messages
        ///     published into the channel)
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<Response<HistoryResult>> History(HistoryParams parameters);

        /// <summary>
        ///     (History in channels is not enabled by default) Allows removing publications in channel history. Current top stream
        ///     position meta data kept untouched to avoid client disconnects due to insufficient state.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<Response<EmptyResult>> HistoryRemove(HistoryRemoveParams parameters);

        /// <summary>
        ///     Return active channels (with one or more active subscribers in it).
        /// </summary>
        /// <returns></returns>
        public Task<Response<ChannelsResult>> Channels();

        /// <summary>
        ///     Allows getting information about running Centrifugo nodes.
        /// </summary>
        /// <returns></returns>
        public Task<Response<InfoResult>> Info();
    }
}