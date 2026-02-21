using System;
using System.Globalization;

namespace GlobalTimeKit.Extensions
{
    public static class DateTimeExtensions
    {
        #region Local <-> UTC

        public static DateTime LocalToUTC(this DateTime localTime)
        {
            return TimeZoneInfo.ConvertTimeToUtc(localTime);
        }

        public static string LocalToUTC(this DateTime localTime, string format)
        {
            return localTime.LocalToUTC().ToString(format, CultureInfo.InvariantCulture);
        }

        public static DateTime UTCToLocal(this DateTime utcTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, TimeZoneInfo.Local);
        }

        public static string UTCToLocal(this DateTime utcTime, string format)
        {
            return utcTime.UTCToLocal().ToString(format, CultureInfo.CurrentCulture);
        }

        #endregion

        #region Nullable DateTime Support

        public static DateTime? LocalToUTC(this DateTime? localTime)
        {
            return localTime.HasValue ? localTime.Value.LocalToUTC() : null;
        }

        public static DateTime? UTCToLocal(this DateTime? utcTime)
        {
            return utcTime.HasValue ? utcTime.Value.UTCToLocal() : null;
        }

        #endregion

        #region String Parsing

        public static DateTime ParseToUTC(this string dateString, string? format = null, CultureInfo? culture = null)
        {
            culture ??= CultureInfo.CurrentCulture;
            DateTime parsed = format == null
                ? DateTime.Parse(dateString, culture)
                : DateTime.ParseExact(dateString, format, culture);

            return parsed.LocalToUTC();
        }

        public static DateTime ParseToLocal(this string dateString, string? format = null, CultureInfo? culture = null)
        {
            culture ??= CultureInfo.CurrentCulture;
            DateTime parsed = format == null
                ? DateTime.Parse(dateString, culture)
                : DateTime.ParseExact(dateString, format, culture);

            return parsed.UTCToLocal();
        }

        #endregion

        #region ISO 8601 Handling

        public static string ToISO8601UTC(this DateTime dateTime)
        {
            return dateTime.LocalToUTC().ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
        }

        public static DateTime ParseISO8601ToUTC(this string isoString)
        {
            return DateTime.Parse(isoString, null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal)
                           .ToUniversalTime();
        }

        #endregion

        #region Unix Timestamp

        public static long ToUnixTimeSecondsUTC(this DateTime dateTime)
        {
            return ((DateTimeOffset)dateTime.LocalToUTC()).ToUnixTimeSeconds();
        }

        public static DateTime FromUnixTimeSecondsUTC(this long seconds)
        {
            return DateTimeOffset.FromUnixTimeSeconds(seconds).UtcDateTime;
        }



        #endregion

        /// <summary>
        /// Returns a human-readable difference between the DateTime and UTC
        /// </summary>
        public static string DifferenceWithUTC(this DateTime dateTime)
        {
            var utcNow = DateTime.UtcNow;
            TimeSpan diff = dateTime.ToUniversalTime() - utcNow;

            return $"Difference with UTC: {Math.Abs(diff.Hours)} hour{(Math.Abs(diff.Hours) != 1 ? "s" : "")} " +
                   $"{Math.Abs(diff.Minutes)} minute{(Math.Abs(diff.Minutes) != 1 ? "s" : "")}";
        }

        /// <summary>
        /// Returns a human-readable difference between the DateTime and Local
        /// </summary>
        public static string DifferenceWithLocal(this DateTime dateTime)
        {
            var localNow = DateTime.Now;
            TimeSpan diff = dateTime - localNow;

            return $"Difference with Local: {Math.Abs(diff.Hours)} hour{(Math.Abs(diff.Hours) != 1 ? "s" : "")} " +
                   $"{Math.Abs(diff.Minutes)} minute{(Math.Abs(diff.Minutes) != 1 ? "s" : "")}";
        }
    }
}