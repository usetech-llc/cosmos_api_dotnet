using System;
using Flurl.Http;

namespace CosmosApi.Extensions
{
    public static class ExceptionsExtensions
    {
        public static Exception WrapException(this Exception exception)
        {
            if (exception is FlurlHttpException flurl)
            {
                return new CosmosHttpException(flurl);
            }

            return exception;
        }
    }
}