namespace UbiquoDotNET.Models;

public record StubDto
{
    //[JsonProperty("request")]
    public required string Name { get; set; }
    public required string Host { get; set; }
    public required RequestDto Request { get; set; }

    //[JsonProperty("response")]
    public required ResponseDto Response { get; set; }
}