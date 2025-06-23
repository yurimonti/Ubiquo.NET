using Microsoft.Extensions.Primitives;
using System.Text.Json.Nodes;

namespace UbiquoDotNET.Abstractions.Fluent
{
    public interface IResponse
    {
        int Status { get; set; }
        JsonNode? Body { get; set; }
        IDictionary<string, IEnumerable<string>> Headers { get; set; }
    }
}
