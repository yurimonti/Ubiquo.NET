using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbiquoDotNet.Fluent
{
    public class UbiquoServicesExtension
    {
        public static void AddUbiquoMock<T, R>(MockClient toMock, UbiquoServer server, bool isIntegration, IServiceCollection services)
            where T : class
            where R : class, T
        {
            string mode = "stubs/";
            if (isIntegration is true) mode = "integration/";
            services.AddHttpClient<T, R>(client =>
            {
                client.BaseAddress = new Uri($"{server.BaseUriSring()}/api/v2/{toMock.ClientName.ToLower()}/{mode}");
            });
        }
    }
}
