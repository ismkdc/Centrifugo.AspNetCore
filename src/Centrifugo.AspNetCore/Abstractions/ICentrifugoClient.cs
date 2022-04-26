using System.Threading.Tasks;
using Centrifugo.AspNetCore.Models.Common;
using Centrifugo.AspNetCore.Models.Request;
using EmptyResponse = Centrifugo.AspNetCore.Models.Response.Empty;
using ChannelsResponse = Centrifugo.AspNetCore.Models.Response.Channels;
using InfoResponse = Centrifugo.AspNetCore.Models.Response.Info;


namespace Centrifugo.AspNetCore.Abstractions
{
    public interface ICentrifugoClient
    {
        /// <summary>
        /// Publish command allows publishing data into a channel.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<Response<EmptyResponse>> Publish(Publish req);

        /// <summary>
        /// Similar to publish but allows to send the same data into many channels.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<Response<EmptyResponse>> Broadcast(Broadcast req);

        /// <summary>
        /// Return active channels (with one or more active subscribers in it).
        /// </summary>
        /// <returns></returns>
        public Task<Response<ChannelsResponse>> Channels();

        /// <summary>
        /// Allows getting information about running Centrifugo nodes.
        /// </summary>
        /// <returns></returns>
        public Task<Response<InfoResponse>> Info();
    }
}