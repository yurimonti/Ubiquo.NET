using System.Text.Json.Nodes;

namespace UbiquoDotNet.Fluent.Abstractions
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