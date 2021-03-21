
using System;
using BenchmarkDotNet.Running;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchmarkTest>();
            /**
             * |            Method |         Mean |      Error |       StdDev |
             * |------------------ |-------------:|-----------:|-------------:|
             * | testSearchInArray | 47,328.38 ns | 935.671 ns | 1,341.912 ns |
             * |  testSearchInHash |     19.69 ns |   0.421 ns |     0.726 ns |
             */
            
            var tree = new Tree(null);
            tree.AddItem(6);
            tree.AddItem(2);
            tree.AddItem(11);
            tree.AddItem(3);
            tree.AddItem(9);
            tree.AddItem(30);
            tree.PrintTree();
            /*
             * [D0 - L] 6
                 [D1 - L] 2
                      [D2 - R] 3
                 [D1 - R] 11
                      [D2 - L] 9
                      [D2 - R] 30

             */
            tree.RemoveItem(6);
            tree.PrintTree();
            /*
             * [D0 - L] 9
                 [D1 - L] 2
                      [D2 - R] 3
                 [D1 - R] 11
                      [D2 - R] 30
             */
            

            var treeRandom = new Tree(null);
            var random = new Random();
            for (int i = 0; i < 30; i++)
            {
                var number = random.Next(1, 100);
                // Console.WriteLine($"Добавлен: {number}");
                treeRandom.AddItem(number);
            }
            treeRandom.PrintTree();
            for (int i = 0; i < 10; i++)
            {
                var number = random.Next(1, 100);
                Console.WriteLine($"Удален: {number}");
                treeRandom.RemoveItem(number);
            }
            treeRandom.PrintTree();
        }
        /** Тестовый прогон на случайных числах
         * [D0 - L] 61
               [D1 - L] 48
                    [D2 - L] 5
                         [D3 - R] 11
                              [D4 - L] 10
                                   [D5 - L] 7
                              [D4 - R] 22
                                   [D5 - L] 16
                                   [D5 - R] 37
                                        [D6 - L] 31
                                        [D6 - R] 47
                    [D2 - R] 60
                         [D3 - L] 50
                              [D4 - R] 52
               [D1 - R] 83
                    [D2 - L] 64
                         [D3 - R] 74
                              [D4 - L] 67
                                   [D5 - R] 72
                              [D4 - R] 77
                    [D2 - R] 88
                         [D3 - L] 86
                              [D4 - L] 85
                              [D4 - R] 87
                         [D3 - R] 90
                              [D4 - R] 92

          Удален: 71
          Удален: 84
          Удален: 40
          Удален: 77
          Удален: 38
          Удален: 66
          Удален: 16
          Удален: 61
          Удален: 19
          Удален: 40
          
          [D0 - L] 64
               [D1 - L] 48
                    [D2 - L] 5
                         [D3 - R] 11
                              [D4 - L] 10
                                   [D5 - L] 7
                              [D4 - R] 22
                                   [D5 - R] 37
                                        [D6 - L] 31
                                        [D6 - R] 47
                    [D2 - R] 60
                         [D3 - L] 50
                              [D4 - R] 52
               [D1 - R] 83
                         [D3 - L] 74
                              [D4 - L] 67
                                   [D5 - R] 72
                    [D2 - R] 88
                         [D3 - L] 86
                              [D4 - L] 85
                              [D4 - R] 87
                         [D3 - R] 90
                              [D4 - R] 92

         */
    }
}