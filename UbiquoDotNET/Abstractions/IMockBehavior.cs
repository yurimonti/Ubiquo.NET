using System;
using System.Text.Json.Nodes;
using UbiquoDotNET.Models;

namespace UbiquoDotNET.Abstractions;

public interface IMockBehavior
{
    MockClient Client {get;}
    Task SetBehavior(HttpRequestMessage request, HttpResponseMessage response);
}
