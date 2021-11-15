using System;

namespace CommonLibrary.Classes
{
    public class DateTimeWrapper
    {
        public static DateTime Now => DateTimeProviderContext.Current == null ? DateTime.Now : DateTimeProviderContext.Current.ContextDateTimeNow;
        public static DateTime UtcNow => Now.ToUniversalTime();
        public static DateTime Today => Now.Date;
    }
}