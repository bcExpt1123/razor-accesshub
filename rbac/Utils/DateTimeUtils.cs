using System;
using System.Globalization;

namespace AccessHub.Utils
{
    public static class DateTimeUtils
    {
        private static readonly CultureInfo CanadianCulture = CultureInfo.GetCultureInfo("en-CA");
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm";

        public static string ToFormattedDateTime(this DateTime dateTime)
        {
            return dateTime.ToLocalTime().ToString(DateTimeFormat, CanadianCulture);
        }

        public static string ToFormattedDateTime(this DateTime? dateTime)
        {
            return dateTime?.ToLocalTime().ToString(DateTimeFormat, CanadianCulture) ?? string.Empty;
        }
    }
} 