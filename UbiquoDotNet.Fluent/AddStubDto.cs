using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbiquoDotNet.Fluent
{
    internal record AddStubDto(string sutName, IEnumerable<StubDto> stubs);
}
