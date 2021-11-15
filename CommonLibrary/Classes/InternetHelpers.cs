using System;
using System.Globalization;
using System.Net;

namespace CommonLibrary.Classes
{
    public class InternetHelpers
    {
        /// <summary>
        /// Get date time from the web as nullable DateTimeOffset
        /// </summary>
        /// <returns>date time or null</returns>
        /// <remarks>This can break dependent on available sites</remarks>
        public static DateTimeOffset? LocalTime()
        {
            var result = GetCurrentTimeFromWeb();
            return result?.ToLocalTime();
        }

        public static DateTimeOffset? GetCurrentTimeFromWeb()
        {
            /*
             * Fail-over sites
             */
            var sites = new[] { "https://nist.time.gov", "http://www.microsoft.com", "http://www.google.com" };

            foreach (var site in sites)
            {
                try
                {
                    var dateTimeOffset = GetTimeFromSite(site);
                    if (dateTimeOffset is not null)
                    {
                        return dateTimeOffset;
                    }
                }
                catch
                {
                    continue;
                }
            }

            return null;

        }

        private static DateTimeOffset? GetTimeFromSite(string site)
        {
            var request = WebRequest.Create(site);
            var response = request.GetResponse();

            string currentHeader = response.Headers["date"];

            var dateTimeOffset = DateTimeOffset.ParseExact(currentHeader!, "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                CultureInfo.InvariantCulture.DateTimeFormat,
                DateTimeStyles.AssumeUniversal);

            return dateTimeOffset;
        }
    }
}