namespace UbiquoDotNet.FluentApi.Abstractions
{
    public interface ISetHeaderAndBodyToRequestStage : IRequestBuilder
    {
        ISetHeaderAndBodyToRequestStage WithRequestBody(string body);
        ISetHeaderAndBodyToRequestStage WithRequestHeaders(params IHeader[] headers);
    }
}