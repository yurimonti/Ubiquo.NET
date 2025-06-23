using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using UbiquoDotNET.Abstractions.Fluent;
using UbiquoDotNET.Models;

namespace UbiquoDotNET.Fluent
{
    public class ReqBuilder : IReqBuilder
    {
        private IRequest _request = new RequestDto();
        public IRequest Build()
        {
            return _request;
        }

        public IReqBuilder WithBody<T>(T body) where T : class
        {
            var serialized = JsonSerializer.Serialize(body);
            var jsonNode = JsonNode.Parse(serialized);
            _request.Body = jsonNode;   
            return this;
        }

        public IReqBuilder WithHeader(params IHeader[] headers)
        {
            IDictionary<string, IEnumerable<string>> requestHeaders = new Dictionary<string, IEnumerable<string>>();
            foreach (var header in headers)
            {
                requestHeaders.Add(new(header.HeaderAttribute, header.HeaderValues));
            }
            _request.Headers = requestHeaders;
            return this;
        }

        public IReqBuilder WithMethod(RequestMethod method)
        {
            _request.Method = method.ToString();
            return this;
        }

        public IReqBuilder WithUri(string uri)
        {
            _request.Uri = uri;
            return this;
        }
    }
}
