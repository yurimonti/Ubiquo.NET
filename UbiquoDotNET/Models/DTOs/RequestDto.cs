using System.Text.Json.Nodes;
using UbiquoDotNET.Abstractions.Fluent;

namespace UbiquoDotNET.Models;

public record RequestDto : IRequest
{
    //[JsonProperty("method")]
    public string Method { get; set; }
    //[JsonProperty("url")]
    public string Uri { get; set; }
    //[JsonProperty("headers")]
    public IDictionary<string, IEnumerable<string>>? Headers { get; set; }
    //[JsonProperty("body")]
    public JsonNode? Body { get; set; }
}
