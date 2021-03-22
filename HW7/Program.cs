using System;

namespace HW7
{
    class Program
    {
        static void Main(string[] args)
        {
            // var board = new Board(1, 1);
            // var board = new Board(2, 2);
            var board = new Board(3, 3);
            // var board = new Board(5, 5);
            // var board = new Board(4, 4);
            var paths = board.GetPaths();
            
            Console.WriteLine($"Кол-во путей для доски {board.Weight}x{board.Height}: {paths.Count}");

            int counter = 0;
            foreach (var path in paths)
            {
                counter++;
                Console.WriteLine($"Вариант пути {counter}:");
                for (int i = 0; i < path.GetLength(0); i++)
                {
                    for (int j = 0; j < path.GetLength(1); j++)
                    {
                        Console.Write(path[i,j] == 1 ? '*': ' ' );
                        Console.Write("\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            /**
             * Кол-во путей для доски 3x3: 6
                Вариант пути 1:
                *
                *
                *       *       *

                Вариант пути 2:
                *
                *       *
                        *       *

                Вариант пути 3:
                *
                *       *       *
                                *

                Вариант пути 4:
                *       *
                        *
                        *       *

                Вариант пути 5:
                *       *
                        *       *
                                *

                Вариант пути 6:
                *       *       *
                                *
                                *

             */
        }
    }
}