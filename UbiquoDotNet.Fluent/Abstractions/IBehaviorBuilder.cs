using System.Net.Http.Json;
using System.Text.Json;

namespace UbiquoDotNet.Fluent.Abstractions
{
    public interface IBehaviorBuilder
    {
        Task Build();
    }
}