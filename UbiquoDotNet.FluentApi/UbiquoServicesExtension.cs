using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbiquoDotNet.FluentApi
{
    /// <summary>
    /// Extension class to register and substitute original HttpClient with the Ubiquo Mocked one
    /// </summary>
    public static class UbiquoServicesExtension
    {
        /// <summary>
        /// Adds a Mocked Ubiquo HttpClient service of the interface specified in <typeparamref name="T"/> 
        /// and the implemented class <typeparamref name="R"/>.       
        /// </summary>
        /// <typeparam name="T">Interface that describes the behavior of the client</typeparam>
        /// <typeparam name="R">Class that implements the <typeparamref name="R"/> interface</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="sutName">Name of the Service Under Test</param>
        /// <param name="toMock">original client attributes</param>
        /// <param name="server">ubiquo server attributes</param>
        /// <param name="isIntegration">testing mode could be integration or unit</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddUbiquoMock<T, R>(this IServiceCollection services, string sutName, MockClient toMock, UbiquoServer server, bool isIntegration)
            where T : class
            where R : class, T
        {
            string mode = "stubs/";
            if (isIntegration is true) mode = "integration/";
            services.AddHttpClient<T, R>(client =>
            {
                client.BaseAddress = new Uri($"{server.BaseUriSring()}/api/v2/{sutName}/{toMock.ClientName.ToLower()}/{mode}");
            });
            return services;
        }
    }
}
