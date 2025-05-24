using System;

namespace UbiquoDotNET.Models;

public class UbiquoServer
{
    public required string Host {get; set;}
    public required int Port {get; set;}

    public string BaseUriSring() => $"{Host}:{Port}";
}
