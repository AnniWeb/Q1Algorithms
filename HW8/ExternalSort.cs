using System;
using System.Collections.Generic;
using System.IO;

namespace HW8
{
    public class ExternalSort
    {
        private static List<int> _tmpData;
        public static void Sort(string dataFileName, string resultFileName, int bucketsSize = 1000)
        {
            List<int> resultArray = new List<int>();
            _tmpData = new List<int>();

            int lineNumber = 0;
            
            var file = new StreamReader(dataFileName);
            string line;
            var step = 0;
            var part = 0;
            var tmpPart = new List<int>();
            var tmpFiles = new Queue<string>();
            
            while ((line = file.ReadLine()) != null)
            {
                int number; 
                Int32.TryParse(line, out number);
                tmpPart.Add(number);
                step++;

                if (step == bucketsSize)
                {
                    tmpPart.Sort();
                    string fileName = resultFileName + "." + part + ".tmp";
                    SavePart(tmpPart, fileName);
                    tmpFiles.Enqueue(fileName);
                    tmpPart.Clear();
                    step = 0;
                    part++;
                }
            }

            if (tmpPart.Count > 0)
            {
                tmpPart.Sort();
                string fileName = resultFileName + "." + part + ".tmp";
                SavePart(tmpPart, fileName);
                tmpFiles.Enqueue(fileName);
                tmpPart.Clear();
            }

            while (tmpFiles.Count > 0)
            {
                var file1 = tmpFiles.Dequeue();
                var file2 = tmpFiles.Count > 0 ? tmpFiles.Dequeue() : null;
                if (file2 == null)
                {
                    File.Move(file1, resultFileName, true); 
                    File.Delete(file1);
                    return;
                }
                tmpFiles.Enqueue(MergePart(file1, file2));
            }
        }
        
        private static void SavePart(List<int> part, string fileName)
        {
            var tmpArray = new List<string>();
            foreach (var number in part)
            {
                tmpArray.Add(number.ToString());
            }
            
            File.WriteAllLines(fileName, tmpArray);
        }

        private static string MergePart(string file1, string file2)
        {
            string fileName = file1 + ".tmp";
            var reader1 = new StreamReader(file1);
            var reader2 = new StreamReader(file2);
            string line;
            int number1, number2;
            
            File.WriteAllText(fileName, String.Empty);
            
            Int32.TryParse(reader1.ReadLine(), out number1);
            Int32.TryParse(reader2.ReadLine(), out number2);

            while (true)
            {
                if (number1 > number2)
                {
                    SaveNumber(fileName, number2);
                    line = reader2.ReadLine();
                    if (line != null)
                    {
                        Int32.TryParse(line, out number2);
                    }
                    else
                    {
                        SaveNumber(fileName, number1);
                        break;
                    }
                }
                else
                {
                    SaveNumber(fileName, number1);
                    line = reader1.ReadLine();
                    if (line != null)
                    {
                        Int32.TryParse(line, out number1);
                    }
                    else
                    {
                        SaveNumber(fileName, number2);
                        break;
                    }
                }
            }
            
            while ((line = reader1.ReadLine()) != null)
            {
                int number;
                Int32.TryParse(line, out number);
                SaveNumber(fileName, number);
            }
            
            while ((line = reader2.ReadLine()) != null)
            {
                int number;
                Int32.TryParse(line, out number);
                SaveNumber(fileName, number);
            }
            
            SaveNumbers(fileName);

            reader1.Close();
            reader2.Close();
            File.Delete(file1);
            File.Delete(file2);
            File.Move(fileName, file1); 
            

            return file1;
        }

        private static void SaveNumber(string fileName, int number)
        {
            _tmpData.Add(number);
            
            if (_tmpData.Count == 100)
            {
                SaveNumbers(fileName);
            }
        }
        
        private static void SaveNumbers(string fileName)
        {
            var tmpArray = new List<string>();
            foreach (var tmp in _tmpData)
            {
                tmpArray.Add(tmp.ToString());
            }
            File.AppendAllLines(fileName, tmpArray);
            _tmpData.Clear();
        }
    }
}