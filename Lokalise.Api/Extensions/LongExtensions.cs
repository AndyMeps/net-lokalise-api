using System;
using System.Collections.Generic;
using System.Text;

namespace Lokalise.Api.Extensions
{
    public static class LongExtensions
    {
        public static DateTime ToUtcDateTime(this long unixTimestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimestamp);
        }
    }
}
