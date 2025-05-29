using System.Net.Http.Json;
using System.Text.Json;

namespace UbiquoDotNet.FluentApi.Abstractions
{
    public interface IBehaviorBuilder
    {
        Task Build();
    }
}