using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbiquoDotNet.FluentApi.Abstractions;

namespace UbiquoDotNet.FluentApi
{
    internal class Behavior
    {
        public IRequest Request { get; set; }
        public IResponse Response { get; set; }
    }
}
