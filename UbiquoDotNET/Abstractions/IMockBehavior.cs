using System;
using System.Text.Json.Nodes;
using UbiquoDotNET.Models;

namespace UbiquoDotNET.Abstractions;

public interface IMockBehavior
{
    MockClient Client { get; set; }
    UbiquoServer UbiquoServer { get; set; }
    string Sut { get; set; }
    Task SetBehavior(HttpRequestMessage request, HttpResponseMessage response);
}
