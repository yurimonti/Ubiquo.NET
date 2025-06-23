using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbiquoDotNET.Models;

namespace UbiquoDotNET.Abstractions.Fluent
{
    public interface IResBuilder
    {
        IResBuilder WithStatus(int status);
        IResBuilder WithBody<T>(T body) where T : class;
        IResBuilder WithHeader(params IHeader[] headers);
        IResponse Build();
    }
}
