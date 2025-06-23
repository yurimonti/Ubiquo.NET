using System.Text.Json.Nodes;

namespace UbiquoDotNet.FluentApi.Abstractions
{
    public interface IResponse
    {
        int Status { get; set; }
        JsonNode? Body { get; set; }
        IDictionary<string, IEnumerable<string>> Headers { get; set; }
    }
}