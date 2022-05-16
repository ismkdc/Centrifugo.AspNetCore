using Centrifugo.AspNetCore.Abstractions;
using Centrifugo.AspNetCore.Configuration;
using Centrifugo.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// ToDo: Add your own configuration
builder.Services.AddCentrifugoClient(
    "http://localhost:8000/api",
    "1c975adb-e03d-4ebe-9bfb-xxxxxx"
);

var app = builder.Build();

app.MapGet("/info", async ([FromServices] ICentrifugoClient centrifugoClient) => await centrifugoClient.Info());

app.MapGet("/publish",
    async ([FromServices] ICentrifugoClient centrifugoClient) =>
        await centrifugoClient.Publish(new { data = "message" }, "channel"));

app.MapGet("/broadcast",
    async ([FromServices] ICentrifugoClient centrifugoClient) =>
        await centrifugoClient.Broadcast(new { data = "message" }, "channel1", "channel2"));

app.Run();