using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using UbiquoDotNET.Abstractions;
using UbiquoDotNET.Exceptions;
using UbiquoDotNET.Models;
using UbiquoDotNET.Models.DTOs;

namespace UbiquoDotNET;

public class MockBehavior : IMockBehavior
{
    public MockClient Client {get; set;}
    public UbiquoServer UbiquoServer {get;set;}
    public string Sut { get; set;}

    private readonly string loadStubApi = "api/v2/admin/stubs/sut";
    private string LoadStubRequestUri() => $"{UbiquoServer.BaseUriSring()}/{loadStubApi}";

    private async Task<JsonNode?> GetBodyFrom(HttpRequestMessage request)
    {
        return request.Content is null ? null : await request.Content?.ReadFromJsonAsync<JsonNode?>();
    }

    private async Task<JsonNode?> GetBodyFrom(HttpResponseMessage response)
    {
        return response.Content is null ? null : await response.Content?.ReadFromJsonAsync<JsonNode?>();
    }

    private async Task<RequestDto> CreateRequestDto(HttpRequestMessage request)
    {
        return new RequestDto()
        {
            Method = request.Method.ToString(),
            Uri = request.RequestUri.PathAndQuery,
            Body = await GetBodyFrom(request),
            Headers = request.Headers.ToDictionary()
        };
    }

    private async Task<ResponseDto> CreateResponseDto(HttpResponseMessage response)
    {
        return new ResponseDto()
        {
            Body = await GetBodyFrom(response),
            Status = (int)response.StatusCode,
            Headers = response.Headers.ToDictionary()
        };
    }

    public async Task SetBehavior(HttpRequestMessage request, HttpResponseMessage response)
    {
        var requestDto = await CreateRequestDto(request);
        var responseDto = await CreateResponseDto(response);
        var stub = new StubDto()
        {
            Host = Client.ClientUri().ToString()+"/",
            Request = requestDto,
            Response = responseDto,
            Name = Client.ClientName.ToLower()
        };
        var stubToAdd = new AddStubDto(Client.ClientName, [stub]);
        using var client = new HttpClient();
        var res = await client.PostAsJsonAsync(LoadStubRequestUri(),stubToAdd,JsonSerializerOptions.Web);
        //if(!res.IsSuccessStatusCode)
        //{
        //    var error = new {error = "stub not valid", stubToAdd };
        //    return JsonSerializer.Serialize(error);
        //}
        string content = await res.Content.ReadAsStringAsync();
        if (!res.IsSuccessStatusCode) throw new StubToAddNotValidException(content);
        //string content = await res.Content.ReadAsStringAsync();
        //return JsonNode.Parse(content);
    }
}
