using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonLibrary.LanguageExtensions
{
    public static class UriHelper
    {
        /// <summary>
        /// Language extension Get params 
        /// </summary>
        /// <param name="uri">contains web address to get parameters</param>
        /// <returns>all parameters</returns>
        public static Dictionary<string, string> GetQueryParameters(this Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (uri.Query.Length == 0)
            {
                return new Dictionary<string, string>();
            }

            return uri.Query.TrimStart('?')
                .Split(new[] { '&', ';' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(parameter => parameter.Split(new[] { '=' },
                    StringSplitOptions.RemoveEmptyEntries))
                .GroupBy(parts => parts[0],
                    parts => parts.Length > 2 ?
                        string.Join("=", parts, 1, parts.Length - 1) : (parts.Length > 1 ? parts[1] : ""))
                .ToDictionary(grouping => grouping.Key,
                    grouping => string.Join(",", grouping));
        }
    }
}