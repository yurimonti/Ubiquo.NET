using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbiquoDotNet.Fluent.Abstractions;

namespace UbiquoDotNet.Fluent
{
    internal class Behavior
    {
        public IRequest Request { get; set; }
        public IResponse Response { get; set; }
    }
}
