using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using System;
using System.Text;

namespace HW4
{
    public class BenchmarkTest
    {
        public List<string> arrayStr = new List<string>();
        public HashSet<string> hashSetStr = new HashSet<string>();
        public string ResultString {get; set;}

        public BenchmarkTest()
        {
            for (int i = 0; i < 10_000; i++)
            {
                var randomStr = RandomString();
                arrayStr.Add(randomStr);
                hashSetStr.Add(randomStr);
            }

            ResultString = RandomString();
        }
        
        public static string RandomString()
        {
            var builder = new StringBuilder();
            Random random = new Random();

            var lenght = random.Next(20, 30);
                
            char ch;
            for (int i = 0; i < lenght; i++)
            {
                //Генерируем число являющееся латинским символом в юникоде
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                //Конструируем строку со случайно сгенерированными символами
                builder.Append(ch);
            }
            return builder.ToString();
        }
        
        [Benchmark]
        public bool testSearchInArray()
        {
            for (int i = 0; i < arrayStr.Count; i++)
            {
                if (arrayStr[i] == ResultString)
                {
                    return true;
                }
            }

            return false;
        }
        
        [Benchmark]
        public bool testSearchInHash()
        {
            return hashSetStr.Contains(ResultString);
        }
    }
}