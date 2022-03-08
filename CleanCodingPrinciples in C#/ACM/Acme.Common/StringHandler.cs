using System;

namespace Acme.Common
{
    public static class StringHandler
    {
        /// <summary>
        /// Inserts spaces before each capital letter in a string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string InsertSpaces(this string source) 
        {
            if (String.IsNullOrWhiteSpace(source)) return source;

            string result = string.Empty;
            char previousLetter = ' ';
            foreach (char letter in source)
            {
                result += !Char.IsWhiteSpace(previousLetter) && char.IsUpper(letter) ? $" {letter}" : letter;
                previousLetter = letter;
            }

            return result;
        }
    }
}
