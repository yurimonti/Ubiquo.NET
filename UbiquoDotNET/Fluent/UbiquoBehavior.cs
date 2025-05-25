using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbiquoDotNET.Abstractions.Fluent;
using UbiquoDotNET.Models;

namespace UbiquoDotNET.Fluent
{
    public class UbiquoBehavior : IUbiquoBehavior
    {
        public MockClient Client { get; set; }
        public UbiquoServer UbiquoServer { get; set; }
        public string Sut { get; set; }
        public IRequestBehavior When(IReqBuilder request)
        {
            IRequest req = request.Build();
            return new RequestBehavior()
            {
                Client = Client,
                UbiquoServer = UbiquoServer,
                Sut = Sut,
                Request = req
            };
        }
    }
}
