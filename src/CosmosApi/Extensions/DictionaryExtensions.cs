using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CosmosApi.Extensions
{
    public static class DictionaryExtensions
    {
        internal static TValue TryGetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TKey: notnull
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }

            return default!;
        }
    }
}