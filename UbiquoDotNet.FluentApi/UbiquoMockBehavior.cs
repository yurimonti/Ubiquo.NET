using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using UbiquoDotNet.FluentApi.Abstractions;
using UbiquoDotNet.FluentApi.Exceptions;

namespace UbiquoDotNet.FluentApi
{
    public class UbiquoMockBehavior :
        ISetMethodStage,
        ISetUriStage,
        ISetHeaderAndBodyToRequestStage,
        IRequestBuilder,
        ISetStatusStage,
        ISetHeaderAndBodyToResponseStage,
        IBehaviorBuilder
    {
        private IRequest _request;

        private IResponse _response;
        public MockClient Client {private get; init; }
        public UbiquoServer UbiquoServer {private get; init; }
        public string Sut {private get; init; }

        private readonly string loadStubApi = "api/v2/admin/stubs/sut";
        private string LoadStubRequestUri() => $"{UbiquoServer.BaseUriSring()}/{loadStubApi}";
        public ISetMethodStage WhenARequest()
        {
            _request = new Request();
            return this;
        }
        public async Task Build()
        {
            var stub = new StubDto()
            {
                Host = Client.ClientUri().ToString(),
                Request = _request,
                Response = _response,
                Name = Client.ClientName.ToLower()
            };
            _request = null;
            _response = null;
            var stubToAdd = new AddStubDto(Sut, [stub]);
            using var client = new HttpClient();
            //TO add
            var postResponse = await client.PostAsJsonAsync(LoadStubRequestUri(), stubToAdd, JsonSerializerOptions.Web);
            //TO delete
            //string json = JsonSerializer.Serialize(stubToAdd, JsonSerializerOptions.Web);
            //var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            //var postResponse = await client.PostAsync(LoadStubRequestUri(), requestContent);
            //if(!res.IsSuccessStatusCode)
            //{
            //    var error = new {error = "stub not valid", stubToAdd };
            //    return JsonSerializer.Serialize(error);
            //}
            string content = await postResponse.Content.ReadAsStringAsync();
            if (!postResponse.IsSuccessStatusCode) throw new StubToAddNotValidException(content);
            //string content = await res.Content.ReadAsStringAsync();
            //return JsonNode.Parse(content);
        }

        public ISetStatusStage ReturnResponse()
        {
            _response = new Response();
            return this;
        }

        //TODO: set JsonNode with WebOptions
        public ISetHeaderAndBodyToRequestStage WithRequestBody(string serializedBody)
        {
            var node = JsonNode.Parse(serializedBody);
            _request.Body = node;
            return this;
        }

        public ISetHeaderAndBodyToRequestStage WithRequestBody(object body)
        {
            string serializedBody = JsonSerializer.Serialize(body, JsonSerializerOptions.Web);
            return WithRequestBody(serializedBody);
        }

        public ISetHeaderAndBodyToRequestStage WithRequestHeaders(params IHeader[] headers)
        {
            IDictionary<string, IEnumerable<string>> requestHeaders = new Dictionary<string, IEnumerable<string>>();
            foreach (var header in headers)
            {
                requestHeaders.Add(new(header.HeaderAttribute, header.HeaderValues));
            }
            _request.Headers = requestHeaders;
            return this;
        }

        public ISetUriStage WithMethod(RequestMethod method)
        {
            _request.Method = method.ToString();
            return this;
        }

        public ISetHeaderAndBodyToResponseStage WithStatus(int status)
        {
            _response.Status = status;
            return this;
        }

        public ISetHeaderAndBodyToRequestStage WithUri(string uri)
        {
            _request.Uri = uri;
            return this;
        }

        public ISetHeaderAndBodyToResponseStage WithResponseHeaders(params IHeader[] headers)
        {
            IDictionary<string, IEnumerable<string>> responseHeader = new Dictionary<string, IEnumerable<string>>();
            foreach (var header in headers)
            {
                responseHeader.Add(new(header.HeaderAttribute, header.HeaderValues));
            }
            _response.Headers = responseHeader;
            return this;
        }

        public ISetHeaderAndBodyToResponseStage WithResponseBody(string body)
        {
            var node = JsonNode.Parse(body);
            _response.Body = node;
            return this;
        }

        public ISetHeaderAndBodyToResponseStage WithResponseBody(object body)
        {
            string serializedBody = JsonSerializer.Serialize(body, JsonSerializerOptions.Web);
            return WithResponseBody(serializedBody);
        }

        
    }
}
