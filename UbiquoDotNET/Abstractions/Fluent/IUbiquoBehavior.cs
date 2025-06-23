using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbiquoDotNET.Models;

namespace UbiquoDotNET.Abstractions.Fluent
{
    public interface IUbiquoBehavior
    {
        MockClient Client { get; set; }
        UbiquoServer UbiquoServer { get; set; }
        string Sut { get; set; }
        IRequestBehavior When(IReqBuilder request);
    }
}
