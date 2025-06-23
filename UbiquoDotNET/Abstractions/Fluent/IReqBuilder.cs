using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using UbiquoDotNET.Models;

namespace UbiquoDotNET.Abstractions.Fluent
{
    public interface IReqBuilder
    {
        IReqBuilder WithMethod(RequestMethod method);
        IReqBuilder WithUri(string uri);
        IReqBuilder WithBody<T>(T body) where T : class;
        IReqBuilder WithHeader(params IHeader[] headers);
        IRequest Build();
    }
}
