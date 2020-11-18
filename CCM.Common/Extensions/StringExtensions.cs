using System;

namespace CCM.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool Between(this String input, String str1, String str2)
        {
            return (input.CompareTo(str1) >= 0 && input.CompareTo(str2) <= 0);
        }
    }
}