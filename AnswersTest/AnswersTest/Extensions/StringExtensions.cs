using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string value)
        {
            if (value == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                return true;
            }

            var trimmed = value.Replace(" ", "").ToUpper();
            return trimmed == new string(trimmed.Reverse().ToArray());
        }
    }
}