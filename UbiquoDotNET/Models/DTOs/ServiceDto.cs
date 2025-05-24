namespace UbiquoDotNET.Models.DTOs;

public record class ServiceDto
{
    public required string ServiceName {get;set;}
    public required string Host {get;set;}
    public required string Port {get;set;}
}
