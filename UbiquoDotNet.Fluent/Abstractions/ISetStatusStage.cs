namespace UbiquoDotNet.Fluent.Abstractions
{
    public interface ISetStatusStage
    {
        ISetHeaderAndBodyToResponseStage WithStatus(int status);
    }
}