using System;

namespace IsbnValidator
{
    public static class Validator
    {
        /// <summary>
        /// Returns true if the specified <paramref name="isbn"/> is valid; returns false otherwise.
        /// </summary>
        /// <param name="isbn">The string representation of 10-digit ISBN.</param>
        /// <returns>true if the specified <paramref name="isbn"/> is valid; false otherwise.</returns>
        /// <exception cref="ArgumentException"><paramref name="isbn"/> is empty or has only white-space characters.</exception>
        public static bool IsIsbnValid(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn) || isbn.Length == 0)
            {
                throw new ArgumentException($"string {nameof(isbn)} can't be null or whitespaces");
            }

            int checkSum = 0;
            int count = 0;

            for (int i = 0; i < isbn.Length; i++)
            {
                if (char.IsNumber(isbn[i]))
                {
                    checkSum += int.Parse(isbn[i].ToString(), System.Globalization.CultureInfo.CurrentCulture) * (10 - count);
                    count++;
                }
                else if (char.IsLetter(isbn[i]) && isbn[i] != 'X')
                {
                    return false;
                }
                else if (isbn[i] == '-' && i != 1 && i != 5 && i != isbn.Length - 2)
                {
                    return false;
                }
            }

            if (isbn[^1] == 'X')
            {
                checkSum += 10;
            }

            if (isbn.Length <= 13 && isbn.Length >= 10 && count >= 9 && count <= 10)
            {
                return checkSum % 11 == 0;
            }

            return false;
        }
    }
}
