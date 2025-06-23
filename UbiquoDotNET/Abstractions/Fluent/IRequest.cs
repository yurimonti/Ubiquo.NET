using Microsoft.Extensions.Primitives;
using System.Text.Json.Nodes;
using UbiquoDotNET.Models;

namespace UbiquoDotNET.Abstractions.Fluent
{
    public interface IRequest
    {
        //[JsonProperty("method")]
        string Method { get; set; }
        //[JsonProperty("url")]
        string Uri { get; set; }
        //[JsonProperty("headers")]
        IDictionary<string, IEnumerable<string>>? Headers { get; set; }
        //[JsonProperty("body")]
        JsonNode? Body { get; set; }
    }
}
