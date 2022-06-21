using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Passwords
{
    public class CaseAlternatorTask
    {
        private static CultureInfo culture;

        //Тесты будут вызывать этот метод
        public static List<string> AlternateCharCases(string lowercaseWord)
        {
            var result = new List<string>();
            AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
            return result;
        }

        static void AlternateCharCases(char[] word, int startIndex, List<string> result)
        {
            if (startIndex == word.Length && !result.Contains(new string(word)))
            {
                result.Add(new string(word));
                return;
            }

            if (char.IsLetter(word[startIndex]) & 
                (char.IsUpper(word[startIndex]) || char.IsLower(word[startIndex]))
                && word[startIndex] != 'ß')
            {
                word[startIndex] = Char.ToLower(word[startIndex]);
                AlternateCharCases(word, startIndex + 1, result);
                word[startIndex] = Char.ToUpper(word[startIndex]);
                AlternateCharCases(word, startIndex + 1, result);
            }
            else
            {
                word[startIndex] = word[startIndex];
                AlternateCharCases(word, startIndex + 1, result);
            }
        }
    }
}