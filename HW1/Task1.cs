using System;

namespace HW1
{
    public class Task1
    {
        public static bool IsPrimeNumber(int number)
        {
            int d = 0;
            int i = 2;

            if (number < 0)
            {
                throw new ArgumentException("Число должно быть натуральным");
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

        public static string IsPrimeNumberToString(int number)
        {
            var result = IsPrimeNumber(number);

            return result ? "Простое" : "Не простое";
        }
    }
}