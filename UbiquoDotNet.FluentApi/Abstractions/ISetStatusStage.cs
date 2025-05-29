namespace UbiquoDotNet.FluentApi.Abstractions
{
    public interface ISetStatusStage
    {
        ISetHeaderAndBodyToResponseStage WithStatus(int status);
    }
}