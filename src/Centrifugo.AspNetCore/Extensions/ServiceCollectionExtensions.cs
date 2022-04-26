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

            services.AddScoped<ICentrifugoClient, CentrifugoClient>();

            return services;
        }
    }
}