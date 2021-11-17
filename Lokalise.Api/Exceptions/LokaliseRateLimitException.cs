using System;
using System.Net.Http;

namespace Lokalise.Api.Exceptions
{
    public sealed class LokaliseRateLimitException : Exception
    {
        public HttpResponseMessage Response { get; }
        public LokaliseRateLimitException(HttpResponseMessage httpResponseMessage) : base("Rate limit reached for the Lokalise API.")
        {
            Response = httpResponseMessage;
        }
    }
}
