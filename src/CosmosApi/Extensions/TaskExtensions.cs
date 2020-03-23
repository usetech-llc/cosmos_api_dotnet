using System.Threading.Tasks;

namespace CosmosApi.Extensions
{
    internal static class TaskExtensions
    {
        public static T Sync<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }
    }
}