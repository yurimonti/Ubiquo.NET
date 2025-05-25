namespace UbiquoDotNet.Fluent.Abstractions
{
    public interface ISetUriStage
    {
        ISetHeaderAndBodyToRequestStage WithUri(string uri);
    }
}