using System;

namespace HW1
{
    public class Task3
    {
        // без рекурсии
        public static int getFibonacciNumber(int number)
        {
            int resultNumber = 0;

            if (number < 0)
            {
                throw new ArgumentException("Данный метод не работает с отрицательными числами");
            }

            while (number != 0)
            {
                resultNumber += number;
                number--;
            }

            return resultNumber;
        }
        
        // Решение с курса по ВВедению с рекурсией
        public static int getFibonacciSequence(int number, ref int[] sequence, bool withNegative = false)
        {
            if (sequence.Length == 0)
            {
                if (number < 0)
                {
                    withNegative = true;
                    sequence = new int[-number*2 + 1];
                }
                else
                {
                    sequence = new int[number + 1];
                }
            }
            int id = withNegative ? sequence.Length/2 + number: number;
            
            // Начальные условия для последовательности Фибоначчи
            if (number == 0)
            {
                return number;
            }

            // Чтобы не искать уже найденное число
            if (sequence[id] != 0)
            {
                return sequence[id];
            }

            int newNumber;

            if (number == 1)
            {
                newNumber = number;
            }
            else if (withNegative && number < 0)
            {
                newNumber = getFibonacciSequence(number + 2, ref sequence, withNegative) - getFibonacciSequence(number + 1, ref sequence, withNegative);
                
                //Для заполнения положительной части последовательности 
                getFibonacciSequence(-number, ref sequence, withNegative);
            }
            else {
                newNumber = getFibonacciSequence(number - 1, ref sequence, withNegative) + getFibonacciSequence(number - 2, ref sequence, withNegative);
            }
            
            
            sequence[id] = newNumber;
            
            return newNumber;
        }
    }
}