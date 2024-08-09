using System;

namespace AbilityMadness.Code.Extensions
{
    public static class TimeExtensions
    {
        public static string ToFormattedTime(this int time)
        {
            // The result must be 00:00
            var result = string.Empty;

            var minutes = time / 60;
            var seconds = time % 60;

            if (minutes < 10)
                result += "0";

            result += $"{minutes}:";

            if (seconds < 10)
                result += "0";

            result += seconds;

            return result;
        }

        public static string ToFormattedString(this TimeSpan timeSpan)
        {
            var result = string.Empty;

            var day = "d";
            var hour = "h";
            var min = "m";
            var second = "s";

            if (timeSpan.TotalSeconds <= 0)
                return $"0{second}";

            if (timeSpan.TotalMinutes < 1)
                return $"{timeSpan.Seconds}{second}";

            if(timeSpan.Days > 0)
                result = $"{timeSpan.Days}{day} ";

            if(timeSpan.Hours > 0)
                result += $"{timeSpan.Hours}{hour} ";

            if (timeSpan.Days < 1)
                result += $"{timeSpan.Minutes}{min}";

            if(timeSpan is {TotalDays: < 1, TotalHours: < 1, TotalMinutes: > 1 })
                result += $" {timeSpan.Seconds}{second}";

            return result;
        }
    }
}
