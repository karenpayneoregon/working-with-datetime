using System;
using System.Threading;

namespace CommonLibrary.Classes
{
    public static class Clock
    {
        private static readonly Func<DateTime> _utcNow = () => DateTime.UtcNow;

        static readonly AsyncLocal<Func<DateTime>> _override = new();

        public static DateTime UtcNow => (_override.Value ?? _utcNow)();

        public static void Set(Func<DateTime> func)
        {
            _override.Value = func;
        }

        public static void Reset()
        {
            _override.Value = null;
        }
    }
}