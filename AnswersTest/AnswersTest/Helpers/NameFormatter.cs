using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnswersTest.Helpers
{
    internal static class NameFormatter
    {
        public static string FormatName(string firstName, string lastName)
        {
            return string.Join(" ", new[] { firstName, lastName });
        }
    }
}