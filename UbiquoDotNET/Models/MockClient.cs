using System;

namespace UbiquoDotNET.Models;

public class MockClient
{
    public string ClientName {get; private set;}
    public string ClientAddress {get; private set;}
    public int ClientPort {get; private set;}

    public MockClient(string clientName, string clientAddress, int clientPort)
    {
        ClientName = clientName;
        ClientAddress = clientAddress;
        ClientPort = clientPort;
    }

    public Uri ClientUri()
    {
        return new Uri(ClientAddress+":"+ClientPort);
    }

}
