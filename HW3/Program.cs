using System;
using System.ComponentModel;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
        
        public static float CalculateDistanceFloat(PointClass pointA, PointClass pointB)
        {
            float x = pointA.Xf - pointB.Xf;
            float y = pointA.Yf - pointB.Yf;

            return MathF.Sqrt(x*x + y*y);
        }
        
        public static double CalculateDistanceDouble(PointClass pointA, PointClass pointB)
        {
            double x = pointA.Xd - pointB.Xd;
            double y = pointA.Yd - pointB.Yd;

            return Math.Sqrt(x*x + y*y);
        }
        
        public static float CalculateDistanceFloat(PointStruct pointA, PointStruct pointB)
        {
            float x = pointA.Xf - pointB.Xf;
            float y = pointA.Yf - pointB.Yf;

            return MathF.Sqrt(x*x + y*y);
        }
        
        public static double CalculateDistanceDouble(PointStruct pointA, PointStruct pointB)
        {
            double x = pointA.Xd - pointB.Xd;
            double y = pointA.Yd - pointB.Yd;

            return Math.Sqrt(x*x + y*y);
        }
        
        public static float CalculateDistanceShortFloat(PointStruct pointA, PointStruct pointB)
        {
            float x = pointA.Xf - pointB.Xf;
            float y = pointA.Yf - pointB.Yf;

            return x*x + y*y;
        }
    }

    public class BenchmarkTest
    {
        public static PointClass[] PointsClass = new PointClass[]
        {
            new PointClass{Xf = 3.5f, Xd = 3.5, Yd = -2.001, Yf = -2.001f},
            new PointClass{Xf = 100.456f, Xd = 100.456, Yd = 90.24, Yf = 90.24f}
        };
        public static PointStruct[] PointStruct = new PointStruct[]
        {
            new PointStruct{Xf = 3.5f, Xd = 3.5, Yd = -2.001, Yf = -2.001f},
            new PointStruct{Xf = 100.456f, Xd = 100.456, Yd = 90.24, Yf = 90.24f}
        };
        /**
         * ||                       Method |     Mean |     Error |    StdDev |
         *  |----------------------------- |---------:|----------:|----------:|
         *  |  Test1CalculateDistanceFloat | 2.442 ns | 0.0837 ns | 0.1531 ns |
         *  |  Test2CalculateDistanceFloat | 2.677 ns | 0.0870 ns | 0.1546 ns |
         *  | Test3CalculateDistanceDouble | 3.057 ns | 0.0973 ns | 0.1231 ns |
         *  |  Test4CalculateDistanceShort | 2.375 ns | 0.0805 ns | 0.1768 ns |

         */

        [Benchmark]
        public void Test1CalculateDistanceFloat()
        {
            Program.CalculateDistanceFloat(PointsClass[0], PointsClass[1]);
        }
        
        [Benchmark]
        public void Test2CalculateDistanceFloat()
        {
            Program.CalculateDistanceFloat(PointStruct[0], PointStruct[1]);
        }
        
        [Benchmark]
        public void Test3CalculateDistanceDouble()
        {
            Program.CalculateDistanceDouble(PointStruct[0], PointStruct[1]);
        }
        
        [Benchmark]
        public void Test4CalculateDistanceShort()
        {
            Program.CalculateDistanceShortFloat(PointStruct[0], PointStruct[1]);
        }
        
    }
}
