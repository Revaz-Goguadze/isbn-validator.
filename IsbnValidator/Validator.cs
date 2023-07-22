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
            // TODO Analyze the method unit tests and implement the method.
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("Source string cannot be null or empty or whitespace.");
            }

            bool result = default;
            if (isbn.Length >= 10 && isbn.Length <= 13)
            {
                List<int> list = StringToList(isbn);
                if (list != null && list.Count == 10)
                {
                    int sum = 0;
                    int x = 10;
                    for (int i = 0; i < list.Count; i++)
                    {
                        sum += list[i] * x--;
                    }

                    if (sum % 11 == 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        private static List<int> StringToList(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            List<int> list = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (int.TryParse(str[i].ToString(), out var number))
                {
                    list.Add(number);
                }
                else if ((i == 1 || i == 5 || i == 11) && str[i] == '-')
                {
                    continue;
                }
                else if (i == str.Length - 1 && str[i] == 'X')
                {
                    list.Add(10);
                }
                else
                {
                    return null;
                }
            }

            return list;
        }
    }
}
