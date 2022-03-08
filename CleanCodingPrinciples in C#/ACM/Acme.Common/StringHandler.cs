using System;

namespace Acme.Common
{
    public static class StringHandler
    {
        public static string InsertSpaces(string source) 
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
