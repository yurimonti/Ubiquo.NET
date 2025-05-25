using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbiquoDotNet.Fluent.Abstractions
{
    public interface ISetMethodStage
    {
        public ISetUriStage WithMethod(RequestMethod method);
    }
}
