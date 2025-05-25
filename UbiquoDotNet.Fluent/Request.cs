using System.Text.Json.Nodes;
using UbiquoDotNet.Fluent.Abstractions;

namespace UbiquoDotNet.Fluent
{
    internal class Request : IRequest
    {
        public string Method { get; set; }
        public string Uri { get; set; }
        public IDictionary<string, IEnumerable<string>>? Headers { get; set; }
        public JsonNode? Body { get; set; }
    }
}