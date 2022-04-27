Centrifugo.AspNetCore is a client for asp.net core 5.0 and 6.0 helps to consume Centrifugo real-time messaging Server
API (https://centrifugal.dev/docs/server/server_api) \
Nuget package: https://www.nuget.org/packages/Centrifugo.AspNetCore/ \
Sample project: https://github.com/ismkdc/Centrifugo.AspNetCore/tree/main/src/Centrifugo.AspNetCore.Sample

```cs
Method list

// Publish command allows publishing data into a channel.
Task<Response<EmptyResponse>> Publish(Publish req);
Task<Response<EmptyResponse>> PublishSimple(string channel, object data);

// Similar to publish but allows to send the same data into many channels.
Task<Response<EmptyResponse>> Broadcast(Broadcast req);
Task<Response<EmptyResponse>> BroadcastSimple(object data, params string[] channels);

// Allows subscribing user to a channel.
Task<Response<EmptyResponse>> Subscribe(Subscribe req);
Task<Response<EmptyResponse>> SubscribeSimple(string user, string channel);

// Allows unsubscribing user from a channel.
Task<Response<EmptyResponse>> UnSubscribe(UnSubscribe req);
Task<Response<EmptyResponse>> UnSubscribeSimple(string user, string channel);

// Allows disconnecting a user by ID.
Task<Response<EmptyResponse>> Disconnect(Disconnect req);
Task<Response<EmptyResponse>> DisconnectSimple(string user);

// Allows refreshing user connection (mostly useful when unidirectional transports are used).
Task<Response<EmptyResponse>> Refresh(Refresh req);
Task<Response<EmptyResponse>> RefreshSimple(string user);

// (Presence in channels is not enabled by default) Allows getting channel online presence information. 
Task<Response<PresenceResponse>> Presence(Presence req);
Task<Response<PresenceResponse>> PresenceSimple(string channel);

// (Presence in channels is not enabled by default) Allows getting short channel presence information - number of clients and number of unique users (based on user ID). 
Task<Response<Presence_StatsResponse>> Presence_Stats(Presence_Stats req);
Task<Response<Presence_StatsResponse>> Presence_StatsSimple(string channel);

// (History in channels is not enabled by default) Allows getting channel history information (list of last messages published into the channel)
Task<Response<HistoryResponse>> History(History req);
Task<Response<HistoryResponse>> HistorySimple(string channel);

// (History in channels is not enabled by default) Allows removing publications in channel history. Current top stream position meta data kept untouched to avoid client disconnects due to insufficient state.
Task<Response<EmptyResponse>> History_Remove(History_Remove req);
Task<Response<EmptyResponse>> History_RemoveSimple(string channel);

// Return active channels (with one or more active subscribers in it).
Task<Response<ChannelsResponse>> Channels();

// Allows getting information about running Centrifugo nodes.
Task<Response<InfoResponse>> Info();

```

Example:

```cs

// Register to IOC

public void ConfigureServices(IServiceCollection services)
{
    // ToDo: Add your own configuration
    var centrifugoConfig = new CentrifugoOptions
    {
        Url = "http://localhost:8000/api",
        ApiKey = "1c975adb-e03d-4ebe-9bfb-xxxxxxxxx"
    };

    services.AddCentrifugoClient(centrifugoConfig);
}


// Use it! :)

public class ExampleService
{
    private readonly ICentrifugoClient _centrifugoClient;

    public ExampleService(ICentrifugoClient centrifugoClient)
    {
        _centrifugoClient = centrifugoClient;
    }

    public async Task TestCentrifugo()
    {
        // Get server info
        var serverInfo = await _centrifugoClient.Info();

        // Get channels info
        var channelsInfo = await _centrifugoClient.Channels();

        // Broadcast something
        await _centrifugoClient.Broadcast(
            new Broadcast()
            {
                Channels = new[] { "channel", "channel2" },
                Data = new { value = 1 }
            });

        // Publish something
        await _centrifugoClient.Publish(
            new Publish()
            {
                Channel = "channel",
                Data = new { value = 1 }
            });
            
       // Also you can use simple versions of methods
       await _centrifugoClient.PublishSimple("channel", new { value = 1 });
       await _centrifugoClient.BroadcastSimple(new { value = 1 }, "channel", "channel2");
    }
}
```