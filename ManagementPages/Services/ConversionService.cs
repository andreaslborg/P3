﻿using System;
using System.Collections.Generic;

namespace ManagementPages.Services
{
    public static class ConversionService
    {
        // Method for when categoryorder should be fetched from database
        public static List<int> ConvertCommaSeparatedStringToListOfInt(string input)
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

        // Method for when categoryorder should be uploaded to database
        public static string ConvertListToCommaSeparatedString<T>(List<T> list)
        {
            var result = string.Empty;

            foreach (var number in list) result += $"{number},";
            result = result.Trim(',');

            return result;
        }
    }
}