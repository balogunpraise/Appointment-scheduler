using System.Diagnostics;
using System.Globalization;

namespace TaskScheduler.Core.Application.Extensions
{
    public static class StringExtensions
    {
        [DebuggerStepThrough]
        public static string ToTitleCase(this string value)
        {
            if(value.IsNotNullOrEmpty())
            {
                CultureInfo culture = CultureInfo.InvariantCulture;
                TextInfo textInfo = culture.TextInfo;
                return textInfo.ToTitleCase(value.Trim().ToLower());
            }
            return String.Empty;
        }

        [DebuggerStepThrough]
        public static bool IsNotNullOrEmpty(this string vaule)
        {
            if(vaule == null)  return false;
            return !string.IsNullOrWhiteSpace(vaule);
        }
    }
}
