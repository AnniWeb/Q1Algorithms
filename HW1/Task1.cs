using System;

namespace HW1
{
    public class Task1
    {
        public static bool IsPrimeNumber(int number, out string error)
        {
            int d = 0;
            int i = 2;
            error = String.Empty;

            if (number < 0)
            {
                error = "Число должно быть натуральным";
                return false;
            }

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }

                i++;
            }
            
            return d == 0;
        }

        public static string IsPrimeNumberToString(int number, out string error)
        {
            var result = IsPrimeNumber(number, out error);

            return result ? "Простое" : "Не простое";
        }
    }
}