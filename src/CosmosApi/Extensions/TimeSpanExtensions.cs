using System;

namespace CosmosApi.Extensions
{
    public static class TimeSpanExtensions
    {
        public static long ToCosmosDuration(this TimeSpan timeSpan)
        {
            return timeSpan.Ticks * 100;
        }

        public static long? ToCosmosDuration(this TimeSpan? timeSpan)
        {
            return timeSpan?.Ticks * 100;
        }
    }
}