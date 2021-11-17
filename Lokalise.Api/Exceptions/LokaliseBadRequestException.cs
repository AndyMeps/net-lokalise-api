using Lokalise.Api.Collections.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lokalise.Api.Exceptions
{
    public sealed class LokaliseBadRequestException : Exception
    {
        public LokaliseError Error { get; }

        public LokaliseBadRequestException(LokaliseError error) : base(error.Message)
        {
            Error = error;
        }
    }
}
