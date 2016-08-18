using System;
using System.Web;

namespace MyApp.Models
{
    /// <summary>
    /// Implements extension methods for DateTime handling
    /// </summary>
    public static class DateTimeHandler
    {
        /// <summary>
        /// Converts a DateTime into a string representing a Sql datetime
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <param name="timeZoneInfoId">TimeZoneInfo ID of dateTime</param>
        public static string ToSqlDate(this DateTime dateTime, string timeZoneInfoId)
        {          
            // Convert to UTC if needed and return SQL string
            return dateTime
                    .ToUtcDate(timeZoneInfoId)
                    .ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
        }

        /// <summary>
        /// Converts a DateTime? into a string representing a Sql datetime
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <param name="timeZoneInfoId">TimeZoneInfo ID of dateTime</param>
        public static string ToSqlDate(this DateTime? dateTime, string timeZoneInfoId)
        {
            // If no value return empty
            if (!dateTime.HasValue)
                return "";

            // Convert to UTC if needed and return SQL string
            return dateTime.Value
                    .ToUtcDate(timeZoneInfoId)
                    .ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
        }

        /// <summary>
        /// Converts a string representing a DateTime into a string representing a Sql datetime
        /// </summary>
        /// <param name="dateTime">DateTime as string</param>
        /// <param name="timeZoneInfoId">TimeZoneInfo ID of dateTime</param>
        public static string ToSqlDate(this string dateTime, string timeZoneInfoId)
        {
            // Parse, convert to UTC and return string
            return DateTime.Parse(dateTime)
                    .ToUtcDate(timeZoneInfoId)
                    .ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
        }

        /// <summary>
        /// Converts a DateTime into a ISO 8601 string
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <param name="timeZoneInfoId">TimeZoneInfo ID of dateTime</param>
        public static string ToIsoString(this DateTime dateTime, string timeZoneInfoId)
        {
            // Convert to UTC if needed and return ISO string
            return dateTime
                    .ToUtcDate(timeZoneInfoId)
                    .ToString("s") + "Z";
        }

        /// <summary>
        /// Converts a DateTime? into a ISO 8601 string
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <param name="timeZoneInfoId">TimeZoneInfo ID of dateTime</param>
        public static string ToIsoString(this DateTime? dateTime, string timeZoneInfoId)
        {
            // If no value return empty
            if (!dateTime.HasValue)
                return "";

            // Convert to UTC if needed and return ISO string
            return dateTime.Value
                    .ToUtcDate(timeZoneInfoId)
                    .ToString("s") + "Z";
        }

        /// <summary>
        /// Converts a string representing a UTC DateTime into a string
        /// representing a local DateTime. If it fails, return string passed as is
        /// </summary>
        /// <param name="dateTime">DateTime as string</param>
        /// <param name="timeZoneInfoId">TimeZoneInfo ID of dateTime</param>
        public static string ToLocalDateString(this string dateTime, string timeZoneInfoId)
        {
            try
            {
                // Parse, convert to local and return string
                return DateTime.Parse(dateTime)
                        .ToLocalDateString(timeZoneInfoId);
            }
            catch
            {
                // Return string as is
                return dateTime;
            }
        }

        /// <summary>
        /// Converts a DateTime into a string representing a local DateTime correctly using a TimeZone
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <param name="timeZoneInfoId">TimeZoneInfo ID of dateTime</param>
        public static string ToLocalDateString(this DateTime dateTime, string timeZoneInfoId)
        {
            // Convert to Local date if needed and return local date string for display
            return dateTime
                    .ToLocalDate(timeZoneInfoId)
                    .ToString();
        }

        /// <summary>
        /// Converts a DateTime? into a string representing a local DateTime correctly using a TimeZone
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <param name="timeZoneInfoId">TimeZoneInfo ID of dateTime</param>
        public static string ToLocalDateString(this DateTime? dateTime, string timeZoneInfoId)
        {
            // If no value return empty
            if (!dateTime.HasValue)
                return "";

            // Convert to Local date string
            return dateTime.Value.ToLocalDateString(timeZoneInfoId);
        }

        /// <summary>
        /// Converts a UTC DateTime into a local DateTime correctly using a TimeZone
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <param name="timeZoneInfoId">TimeZoneInfo ID of dateTime</param>
        private static DateTime ToLocalDate(this DateTime dateTime, string timeZoneInfoId)
        {
            // If already Local return
            if (dateTime.Kind == DateTimeKind.Local)
                return dateTime;

            // If no TimeZone return .ToLocalTime
            if (string.IsNullOrEmpty(timeZoneInfoId))
                return dateTime.ToLocalTime();

            // Correctly convert from UTC with TimeZoneInfo
            return TimeZoneInfo
                        .ConvertTimeFromUtc(
                            dateTime,
                            TimeZoneInfo.FindSystemTimeZoneById(timeZoneInfoId)
                        );
        }

        /// <summary>
        /// Converts a DateTime to UTC correctly with TimeZoneInfo
        /// </summary>
        /// <param name="dateTime">DateTime to UTC</param>
        /// <param name="timeZoneInfoId">TimeZoneInfo ID of dateTime</param>
        public static DateTime ToUtcDate(this DateTime dateTime, string timeZoneInfoId)
        {
            // If already UTC return
            if (dateTime.Kind == DateTimeKind.Utc)
                return dateTime;

            // If local (e.g. DateTime.Now) return normal convert
            if (dateTime.Kind == DateTimeKind.Local)
                return dateTime.ToUniversalTime();

            // Get TimeZone with timeZoneInfoId or default(UTC)
            TimeZoneInfo timeZoneInfo = string.IsNullOrEmpty(timeZoneInfoId)
                                        ? TimeZoneInfo.Utc
                                        : TimeZoneInfo.FindSystemTimeZoneById(timeZoneInfoId);

            // Correctly convert to UTC with TimeZoneInfo
            return TimeZoneInfo.ConvertTimeToUtc(dateTime, timeZoneInfo);
        }
    }
}
