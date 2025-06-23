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
    public class ResBuilder : IResBuilder
    {
        private IResponse _response = new ResponseDto();
        public IResponse Build()
        {
            return _response;
        }

        public IResBuilder WithBody<T>(T body) where T : class
        {
            var serialized = JsonSerializer.Serialize(body);
            var jsonNode = JsonNode.Parse(serialized);
            _response.Body = jsonNode;
            return this;
        }

        public IResBuilder WithHeader(params IHeader[] headers)
        {
            IDictionary<string, IEnumerable<string>> requestHeaders = new Dictionary<string, IEnumerable<string>>();
            foreach (var header in headers)
            {
                requestHeaders.Add(new(header.HeaderAttribute, header.HeaderValues));
            }
            _response.Headers = requestHeaders;
            return this;
        }

        public IResBuilder WithStatus(int status)
        {
            _response.Status = status;
            return this;
        }
    }
}
