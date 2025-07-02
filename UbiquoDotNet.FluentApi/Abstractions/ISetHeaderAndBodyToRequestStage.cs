namespace UbiquoDotNet.FluentApi.Abstractions
{
    public interface ISetHeaderAndBodyToRequestStage : IRequestBuilder
    {
        ISetHeaderAndBodyToRequestStage WithRequestBody(string body);
        ISetHeaderAndBodyToRequestStage WithRequestBody(object body);
        ISetHeaderAndBodyToRequestStage WithRequestHeaders(params IHeader[] headers);
    }
}