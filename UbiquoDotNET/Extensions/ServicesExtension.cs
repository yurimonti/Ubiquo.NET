using System;
using Microsoft.Extensions.DependencyInjection;
using UbiquoDotNET.Models;

namespace UbiquoDotNET.Extensions;

public static class ServicesExtension
{
    public static void AddUbiquoMock<T,R>(MockClient toMock, UbiquoServer server,bool isIntegration ,IServiceCollection services)
    where T : class
    where R : class, T
    {
        string mode = "stubs/";
        if(isIntegration is true) mode = "integration/";
        services.AddHttpClient<T,R>(client => {
            client.BaseAddress = new Uri($"{server.BaseUriSring()}/api/v2/{toMock.ClientName.ToLower()}/{mode}");
        });
    }
}
