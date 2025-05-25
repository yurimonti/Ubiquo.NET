namespace UbiquoDotNet.Fluent.Abstractions
{
    public interface IMockClient
    {
        string ClientName { get; }

        string ClientUri();
    }
}