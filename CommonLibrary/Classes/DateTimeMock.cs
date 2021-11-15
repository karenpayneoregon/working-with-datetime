using System;
using System.Threading;

namespace CommonLibrary.Classes
{
    /// <summary>
    /// DateTime provider, which provide access for getting actual datetime.
    /// </summary>
    public class DateTimeMock : IDisposable
    {
        private static readonly AsyncLocal<DateTime?> _injectedDateTime = new();

        /// <summary>
        /// Gets DateTime now.
        /// </summary>
        /// <value>
        /// The DateTime now.
        /// </value>
        public static DateTime Now => _injectedDateTime.Value ?? DateTime.Now;

        /// <summary>
        /// Injects the actual date time.
        /// </summary>
        /// <param name="actualDateTime">The actual date time.</param>
        public static IDisposable Inject(DateTime actualDateTime)
        {
            _injectedDateTime.Value = actualDateTime;

            return new DateTimeMock();
        }

        public void Dispose()
        {
            _injectedDateTime.Value = null;
        }
    }
}