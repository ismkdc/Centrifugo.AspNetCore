Centrifugo.AspNetCore is a client for asp.net core 5.0 and 6.0 helps to consume Centrifugo real-time messaging Server API (https://centrifugal.dev/docs/server/server_api) \
Nuget package: https://www.nuget.org/packages/Centrifugo.AspNetCore/ \
Sample project: https://github.com/ismkdc/Centrifugo.AspNetCore/tree/main/src/Centrifugo.AspNetCore.Sample

Example: 
<pre>

1-) Register to IOC

// ToDo: Add your own configuration
var centrifugoConfig = new CentrifugoOptions
{
    Url = "http://localhost:8000/api",
    ApiKey = "1c975adb-e03d-4ebe-9bfb-xxxxxxxxx"
};

builder.Services.AddCentrifugoClient(centrifugoConfig);

---------------------

2-) Use it! :)

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
    }
}
</pre>
