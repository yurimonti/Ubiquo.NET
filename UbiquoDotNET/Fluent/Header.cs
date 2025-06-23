using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbiquoDotNET.Abstractions.Fluent;

namespace UbiquoDotNET.Fluent
{
    public class Header : IHeader
    {
        public string HeaderAttribute { get; set; }
        public IEnumerable<string> HeaderValues { get; set; }
    }
}
