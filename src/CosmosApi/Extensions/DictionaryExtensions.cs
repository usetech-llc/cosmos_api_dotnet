using System.Collections.Generic;

namespace CosmosApi.Extensions
{
    public static class DictionaryExtensions
    {
        internal static TValue TryGetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }

            return default;
        }
    }
}