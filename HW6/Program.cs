using System;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Тестовый граф - двунаправоенный 
            /*
             * 		A	B	C	D	E	F	G
                A		1					
                B	1		1	1	1	1	
                C		1					1
                D		1					
                E		1				1	
                F		1			1		1
                G			1			1	
             */
            
            var graph = new Graph();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddEdge("A", "B", 1);
            graph.AddEdge("B", "A", 1);
            graph.AddEdge("B", "C", 1);
            graph.AddEdge("B", "D", 1);
            graph.AddEdge("B", "E", 1);
            graph.AddEdge("B", "F", 1);
            graph.AddEdge("C", "B", 1);
            graph.AddEdge("C", "G", 1);
            graph.AddEdge("D", "B", 1);
            graph.AddEdge("E", "B", 1);
            graph.AddEdge("E", "F", 1);
            graph.AddEdge("F", "B", 1);
            graph.AddEdge("F", "E", 1);
            graph.AddEdge("F", "G", 1);
            graph.AddEdge("G", "C", 1);
            graph.AddEdge("G", "F", 1);
            
            graph.widthTraversal();// A - B - C - D - E - F - G - end
            graph.depthTraversal();// A - B - F - G - C - E - D - end
        }
    }
}