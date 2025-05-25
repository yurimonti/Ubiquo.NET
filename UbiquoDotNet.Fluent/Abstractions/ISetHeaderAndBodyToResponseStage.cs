namespace UbiquoDotNet.Fluent.Abstractions
{
    public interface ISetHeaderAndBodyToResponseStage : IBehaviorBuilder
    {
        ISetHeaderAndBodyToResponseStage WithBody<T>(T body);
        ISetHeaderAndBodyToResponseStage WithHeaders(params IHeader[] headers);
    }
}