using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbiquoDotNet.FluentApi
{
    public class UbiquoServer
    {
        public required string Host { get; set; }
        public required int Port { get; set; }

        public string BaseUriSring() => $"{Host}:{Port}";
    }
}
