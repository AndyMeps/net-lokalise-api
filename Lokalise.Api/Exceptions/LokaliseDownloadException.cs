using System;
using System.Net.Http;

namespace Lokalise.Api.Exceptions
{
    public sealed class LokaliseDownloadException : Exception
    {
        public HttpResponseMessage Response { get; }
        public LokaliseDownloadException(HttpResponseMessage httpResponseMessage) : base("Download request not acceptable, possibly requesting the wrong format?")
        {
            Response = httpResponseMessage;
        }
    }
}
