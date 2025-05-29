namespace UbiquoDotNet.FluentApi.Abstractions
{
    public interface ISetHeaderAndBodyToResponseStage : IBehaviorBuilder
    {
        ISetHeaderAndBodyToResponseStage WithResponseBody(string body);
        ISetHeaderAndBodyToResponseStage WithResponseHeaders(params IHeader[] headers);
    }
}