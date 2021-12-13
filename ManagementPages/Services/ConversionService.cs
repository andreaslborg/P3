using System;
using System.Collections.Generic;

namespace ManagementPages.Services
{
    public static class ConversionService
    {

        public static List<int> ConvertToListOfInt(string input)
        {
            List<int> result = new();
            var list = input.Split(',');

            foreach (var numberString in list)
                try
                {
                    var number = int.Parse(numberString);
                    result.Add(number);
                }
                catch (FormatException)
                {
                    // Handle
                }

            return result;
        }

        public static string ConvertToCommaSeparatedString(List<int> list)
        {
            var result = string.Empty;

            foreach (var number in list) result += $"{number},";

            return result;
        }
    }
}
