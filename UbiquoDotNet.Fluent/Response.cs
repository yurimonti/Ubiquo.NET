using System.Text.Json.Nodes;
using UbiquoDotNet.Fluent.Abstractions;

namespace UbiquoDotNet.Fluent
{
    internal class Response : IResponse
    {
        public int Status { get; set; }
        public JsonNode? Body { get; set; }
        public IDictionary<string, IEnumerable<string>>? Headers { get; set; }
    }
}