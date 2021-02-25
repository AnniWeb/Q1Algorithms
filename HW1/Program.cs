using System;

namespace HW1
{
    class TestCaseTask1
    {
        public int InputNumber { get; set; }
        public bool Expected { get; set; }

        public void exec()
        {
            var resultExpectedString = Expected ? "Простое" : "Не простое";
            Console.WriteLine($"Входящее число: {InputNumber}");
            
            try
            {
                var resultOut = Task1.IsPrimeNumber(InputNumber);
                var resultOutString = resultOut ? "Простое" : "Не простое";
                Console.WriteLine($"Полученный результат: {resultOut}, в текстовом виде: {resultOutString}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
            
            Console.WriteLine($"Ожидаемый результат: {Expected}, в текстовом виде: {resultExpectedString}");
        }
    }
    
    class TestCaseTask3
    {
        public int InputNumber { get; set; }
        public int Expected { get; set; }

        public void exec()
        {
            int[] sequence = new int[0];
            Console.WriteLine($"Входящее число: {InputNumber}");

            try
            {
                var resultOutRec = Task3.getFibonacciNumber(InputNumber);
                Console.WriteLine($"Полученный результат без рекурсии: {resultOutRec}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }

            try
            {
                var resultOutWRec = Task3.getFibonacciSequence(InputNumber, ref sequence);
                Console.WriteLine($"Полученный результат c рекурсией: {resultOutWRec}");
                Console.WriteLine($"Последовательность: {String.Join(", ", sequence)}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
            
            Console.WriteLine($"Ожидаемый результат: {Expected}");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1");
            TestCaseTask1[] testCaseTask1 = 
            {
                new TestCaseTask1()
                {
                    InputNumber = 1,
                    Expected = true
                },
                new TestCaseTask1()
                {
                    InputNumber = 1,
                    Expected = true
                },
                new TestCaseTask1()
                {
                    InputNumber = 100,
                    Expected = false
                },
                new TestCaseTask1()
                {
                    InputNumber = -53,
                    Expected = false
                },
            };

            foreach (var testCase in testCaseTask1)
            {
                testCase.exec();
                Console.WriteLine();
            }
            Console.WriteLine();
            
            // задача 2 см. Task2.cs
            Console.WriteLine("Задача 2");
            Console.WriteLine("Асимптотическую сложность функции = O(N^3)");
            
            Console.WriteLine();
            Console.WriteLine();
            
            
            Console.WriteLine("Задача 3");
            TestCaseTask3[] testCaseTask3 = 
            {
                new TestCaseTask3()
                {
                    InputNumber = 0,
                    Expected = 0
                },
                new TestCaseTask3()
                {
                    InputNumber = 1,
                    Expected = 1
                },
                new TestCaseTask3()
                {
                    InputNumber = 10,
                    Expected = 55
                },
                new TestCaseTask3()
                {
                    InputNumber = -10,
                    Expected = -55
                },
            };
            
            foreach (var testCase in testCaseTask3)
            {
                testCase.exec();
                Console.WriteLine();
            }
        }
    }
}
