using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UbiquoDotNET.Abstractions.Fluent;
using UbiquoDotNET.Exceptions;
using UbiquoDotNET.Models;
using UbiquoDotNET.Models.DTOs;

namespace UbiquoDotNET.Fluent
{
    public class RequestBehavior : IRequestBehavior
    {

        public MockClient Client { get; init; }
        public UbiquoServer UbiquoServer { get; init; }
        public string Sut { get; init; }
        public IRequest Request {  get; set; }
        //TODO: to add in appSettings
        private readonly string loadStubApi = "api/v2/admin/stubs/sut";
        private string LoadStubRequestUri() => $"{UbiquoServer.BaseUriSring()}/{loadStubApi}";
        //TODO: to implement
        public async Task ThenReturn(IResBuilder response)
        {
            IResponse res = response.Build();
            var stub = new StubDto()
            {
                Host = Client.ClientUri().ToString(),
                Request = (RequestDto)Request,
                Response = (ResponseDto)res,
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
    }
}
