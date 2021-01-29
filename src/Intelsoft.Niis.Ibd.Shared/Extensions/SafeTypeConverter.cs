using System;

namespace Intelsoft.Niis.Ibd.Shared.Extensions
{
    public static class SafeTypeConverterExtensions
    {
        public static DateTime? Convert(this string input, DateTime? defaultValue)
        {
            if (input == null) return defaultValue;

            return DateTime.TryParse(input.Trim(), out var dateTime) ? dateTime : defaultValue;
        }

        public static DateTime Convert(this string input, DateTime defaultValue)
        {
            if (input == null) return defaultValue;

            return DateTime.TryParse(input.Trim(), out var dateTime) ? dateTime : defaultValue;
        }
    }
}
