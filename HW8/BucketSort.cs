using System.Collections.Generic;

namespace HW8
{
    public class BucketSort
    {
        public static List<int> Sort(int[] array, int bucketsCount = 100)
        {
            List<int> resultArray = new List<int>();
            
            List<int>[] bucketsPositive = new List<int>[bucketsCount];
            List<int>[] bucketsNegative = new List<int>[bucketsCount];
            int max = 0;
            int min = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            for (int i = 0; i < bucketsCount; i++)
            {
                if (max > 0)
                {
                    bucketsPositive[i] = new List<int>();
                }

                if (min < 0)
                {
                    bucketsNegative[i] = new List<int>();
                }
            }
            
            for (int i = 0; i < array.Length; i++)
            {
                bool sign = array[i] <= 0;
                int step = (sign ? min : max) / bucketsCount;
                int bucket = step != 0 ? array[i] / step : 0;
                
                if (bucket > bucketsCount - 1)
                {
                    bucket = bucketsCount - 1;
                }
                
                if (sign)
                {
                    bucketsNegative[bucket].Add(array[i]);
                }
                else
                {
                    bucketsPositive[bucket].Add(array[i]);
                }
            }
            
            for (int i = bucketsNegative.Length-1; i >= 0; i--)
            {
                bucketsNegative[i].Sort();
                resultArray.AddRange(bucketsNegative[i]);
            }
            
            for (int i = 0; i < bucketsPositive.Length; i++)
            {
                bucketsPositive[i].Sort();
                resultArray.AddRange(bucketsPositive[i]);
            }

            return resultArray;
        }
    }
}