Centrifugo.AspNetCore is a client for asp.net core 5.0 and 6.0 helps to consume Centrifugo real-time messaging Server
- API (https://centrifugal.dev/docs/server/server_api) 
- Nuget package: https://www.nuget.org/packages/Centrifugo.AspNetCore/ 
- Sample project: https://github.com/ismkdc/Centrifugo.AspNetCore/tree/main/src/Centrifugo.AspNetCore.Sample

```cs
Method list

// Publish command allows publishing data into a channel.
Task<Response<EmptyResponse>> Publish(PublishParams req);
Task<Response<EmptyResponse>> Publish(object data, string channel);

// Similar to publish but allows to send the same data into many channels.
Task<Response<EmptyResponse>> Broadcast(BroadcastParams req);
Task<Response<EmptyResponse>> Broadcast(object data, params string[] channels);

// Allows subscribing user to a channel.
Task<Response<EmptyResponse>> Subscribe(SubscribeParams req);
Task<Response<EmptyResponse>> Subscribe(string user, string channel);

// Allows unsubscribing user from a channel.
Task<Response<EmptyResponse>> UnSubscribe(UnSubscribeParams req);
Task<Response<EmptyResponse>> UnSubscribe(string user, string channel);

// Allows disconnecting a user by ID.
Task<Response<EmptyResponse>> Disconnect(DisconnectParams req);
Task<Response<EmptyResponse>> Disconnect(string user);

// Allows refreshing user connection (mostly useful when unidirectional transports are used).
Task<Response<EmptyResponse>> Refresh(RefreshParams req);
Task<Response<EmptyResponse>> Refresh(string user);

// (Presence in channels is not enabled by default) Allows getting channel online presence information. 
Task<Response<PresenceResponse>> Presence(PresenceParams req);
Task<Response<PresenceResponse>> Presence(string channel);

// (Presence in channels is not enabled by default) Allows getting short channel presence information - number of clients and number of unique users (based on user ID). 
Task<Response<Presence_StatsResponse>> PresenceStats(PresenceStatsParams req);
Task<Response<Presence_StatsResponse>> PresenceStats(string channel);

// (History in channels is not enabled by default) Allows getting channel history information (list of last messages published into the channel)
Task<Response<HistoryResponse>> History(HistoryParams req);
Task<Response<HistoryResponse>> History(string channel);

// (History in channels is not enabled by default) Allows removing publications in channel history. Current top stream position meta data kept untouched to avoid client disconnects due to insufficient state.
Task<Response<EmptyResponse>> HistoryRemove(HistoryRemoveParams req);
Task<Response<EmptyResponse>> HistoryRemove(string channel);

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

    services.AddCentrifugoClient("http://localhost:8000/api", "1c975adb-e03d-4ebe-9bfb-xxxxxxxxx");
    
    // OR
    
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
       await _centrifugoClient.Publish(new { value = 1 }, "channel");
       await _centrifugoClient.Broadcast(new { value = 1 }, "channel", "channel2");
    }
}
```
