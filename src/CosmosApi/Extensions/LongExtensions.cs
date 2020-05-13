using System;

namespace CosmosApi.Extensions
{
    public static class LongExtensions
    {
        /// <summary>
        /// Converts cosmos duration to dotnet <see cref="TimeSpan"/>. Warning: possible loss of precision.
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static TimeSpan CosmosDurationToTimeSpan(this long duration)
        {
            return new TimeSpan(duration / 100);
        }

        /// <summary>
        /// Converts cosmos duration to dotnet <see cref="TimeSpan"/>. Warning: possible loss of precision.
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static TimeSpan? CosmosDurationToTimeSpan(this long? duration)
        {
            if (duration == null)
            {
                return null;
            }
            return new TimeSpan(duration.Value / 100);
        }
    }
}