using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using UbiquoDotNet.Fluent.Abstractions;
using UbiquoDotNet.Fluent.Exceptions;

namespace UbiquoDotNet.Fluent
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
        public MockClient Client { get; set; }
        public UbiquoServer UbiquoServer { get; set; }
        public string Sut { get; set; }
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
            var stubToAdd = new AddStubDto(Sut, [stub]);
            using var client = new HttpClient();
            var postResponse = await client.PostAsJsonAsync(LoadStubRequestUri(), stubToAdd, JsonSerializerOptions.Web);
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

        public ISetHeaderAndBodyToRequestStage WithBody<T>(T body)
        {
            string serialized = JsonSerializer.Serialize(body);
            var node = JsonNode.Parse(serialized);
            _request.Body = node;
            return this;
        }

        public ISetHeaderAndBodyToRequestStage WithHeaders(params IHeader[] headers)
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

        ISetHeaderAndBodyToResponseStage ISetHeaderAndBodyToResponseStage.WithBody<T>(T body)
        {
            string serialized = JsonSerializer.Serialize(body);
            var node = JsonNode.Parse(serialized);
            _response.Body = node;
            return this;
        }

        ISetHeaderAndBodyToResponseStage ISetHeaderAndBodyToResponseStage.WithHeaders(params IHeader[] headers)
        {
            IDictionary<string, IEnumerable<string>> responseHeader = new Dictionary<string, IEnumerable<string>>();
            foreach (var header in headers)
            {
                responseHeader.Add(new(header.HeaderAttribute, header.HeaderValues));
            }
            _response.Headers = responseHeader;
            return this;
        }
    }
}
