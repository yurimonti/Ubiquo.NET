namespace UbiquoDotNet.FluentApi.Abstractions
{
    public interface IMockClient
    {
        string ClientName { get; }

        string ClientUri();
    }
}