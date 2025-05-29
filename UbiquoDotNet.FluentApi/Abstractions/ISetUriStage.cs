namespace UbiquoDotNet.FluentApi.Abstractions
{
    public interface ISetUriStage
    {
        ISetHeaderAndBodyToRequestStage WithUri(string uri);
    }
}