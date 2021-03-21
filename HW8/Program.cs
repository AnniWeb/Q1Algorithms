using System;
using System.Collections.Generic;
using System.IO;

namespace HW8
{
    class Program
    {
        static void Main(string[] args)
        {
            var testSize = 10_000;
            var testFileWithData = $"test_start_{testSize}.data";
            var testResultBucketFile = "test_backet.data";
            var testResultExternalFile = "test_external.data";
            
            var testData = GetTestData(testFileWithData, testSize);
            
            var resultBacket = BucketSort.Sort(testData);
            SaveArray(resultBacket, testResultBucketFile);
            
            ExternalSort.Sort(testFileWithData, testResultExternalFile);
        }

        public static int[] GetTestData(string fineName, int testSize)
        {
            var fileInfo = new FileInfo(fineName);
            var rand = new Random();
            int[] testData = new int[testSize];

            if (!fileInfo.Exists || fileInfo.Length == 0)
            {
                File.WriteAllText(fineName, String.Empty);
                for (int i = 0; i < testSize; i++)
                {
                    int number = rand.Next(0, 1_000_000);
                    var sign = rand.Next(0, 100) >= 50 ? "-" : String.Empty;
                    testData[i] = number;
                    File.AppendAllText(fineName, sign + number.ToString() + Environment.NewLine);
                }
            }
            else
            {
                var file = new StreamReader(fineName);
                string line;
                var i = 0;
                while ((line = file.ReadLine()) != null)
                {
                    if (i < testData.Length)
                    {
                        Int32.TryParse(line, out testData[i]);
                    }
                    else
                    {
                        break;
                    }

                    i++;
                }

                file.Close();

            }

            return testData;
        }
        
        public static void SaveArray(List<int> array, string fileName)
        {
            File.WriteAllText(fileName, String.Empty);
            foreach (var number in array)
            {
                File.AppendAllText(fileName, number.ToString() + Environment.NewLine);
            }
        }
    }
}