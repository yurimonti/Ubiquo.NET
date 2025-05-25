using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbiquoDotNET.Models;

namespace UbiquoDotNET.Abstractions.Fluent
{
    public interface IRequestBehavior
    {
        MockClient Client { get; init; }
        UbiquoServer UbiquoServer { get; init; }
        string Sut { get; init; }
        Task ThenReturn(IResBuilder response);
    }
}
