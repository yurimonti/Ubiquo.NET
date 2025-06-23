using System.Text.Json.Nodes;
using UbiquoDotNET.Abstractions.Fluent;

namespace UbiquoDotNET.Models;

public record ResponseDto : IResponse
{
    //[JsonProperty("status")]
    public int Status { get; set; }
    //[JsonProperty("headers")]
    public IDictionary<string, IEnumerable<string>>? Headers { get; set; }
    //[JsonProperty("body")]
    public JsonNode? Body { get; set; }
}
