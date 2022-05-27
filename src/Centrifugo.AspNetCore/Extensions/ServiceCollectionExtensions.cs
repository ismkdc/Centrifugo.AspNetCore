using System;
using Centrifugo.AspNetCore.Abstractions;
using Centrifugo.AspNetCore.Configuration;
using Centrifugo.AspNetCore.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Centrifugo.AspNetCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static string NamedClientName => "CentrifugoClient";

        public static IServiceCollection AddCentrifugoClient(this IServiceCollection services,
            CentrifugoOptions configureOptions)
        {
            if (configureOptions == null) throw new ArgumentNullException(nameof(configureOptions));

            services.AddHttpClient(NamedClientName, httpClient =>
            {
                httpClient.BaseAddress = new Uri(configureOptions.Url);
                httpClient.DefaultRequestHeaders.Add(
                    "Authorization", $"apikey {configureOptions.ApiKey}");
            });

            services.AddSingleton<ICentrifugoClient, CentrifugoClient>();

            return services;
        }

        public static IServiceCollection AddCentrifugoClient(this IServiceCollection services,
            string url, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(apiKey))
                throw new Exception("Url and ApiKey must be specified");

            var options = new CentrifugoOptions
            {
                ApiKey = apiKey,
                Url = url
            };

            return services.AddCentrifugoClient(options);
        }
    }
}