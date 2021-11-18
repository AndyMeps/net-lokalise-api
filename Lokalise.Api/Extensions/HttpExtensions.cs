using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace Lokalise.Api.Extensions
{
    internal static class HttpExtensions
    {
        internal static string ToQueryString(this NameValueCollection collection)
        {
            // This is based off the NameValueCollection.ToString() implementation
            var count = collection.Count;
            if (count == 0)
                return string.Empty;

            var stringBuilder = new StringBuilder();

            for (var i = 0; i < count; i++)
            {
                var text = collection.GetKey(i);
                text = HttpUtility.UrlEncode(text);
                var value = text != null ? text + "=" : string.Empty;
                var values = collection.GetValues(i);
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append('&');
                }
                if (values == null || values.Length == 0)
                {
                    stringBuilder.Append(value);
                }
                else
                {
                    if (values.Length == 1)
                    {
                        stringBuilder.Append(value);
                        var text2 = values[0];
                        text2 = HttpUtility.UrlEncode(text2);
                        stringBuilder.Append(text2);
                    }
                    else
                    {
                        for (var j = 0; j < values.Length; j++)
                        {
                            if (j > 0)
                            {
                                stringBuilder.Append('&');
                            }
                            stringBuilder.Append(value);
                            var text2 = values[j];
                            text2 = HttpUtility.UrlEncode(text2);
                            stringBuilder.Append(text2);
                        }
                    }
                }
            }

            return stringBuilder.ToString();
        }

    }
}
