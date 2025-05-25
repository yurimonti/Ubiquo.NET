namespace UbiquoDotNet.Fluent.Abstractions
{
    public interface ISetHeaderAndBodyToRequestStage : IRequestBuilder
    {
        ISetHeaderAndBodyToRequestStage WithBody<T>(T body);
        ISetHeaderAndBodyToRequestStage WithHeaders(params IHeader[] headers);
    }
}