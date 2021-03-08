using System;
using System.Collections.Generic;

namespace HW6
{
    public class Graph
    {
		public List<Node> Vertices { get; }

		public Graph()
		{
			Vertices = new List<Node>();
		}
		
		public void AddVertex(string name)
		{
			Vertices.Add(new Node(name));
		}

		public Node FindVertex(string name)
		{
			foreach (var v in Vertices)
			{
				if (v.Name.Equals(name))
				{
					return v;
				}
			}

			return null;
		}

		public void AddEdge(string firstName, string secondName, int weight)
		{
			var v1 = FindVertex(firstName);
			var v2 = FindVertex(secondName);
			if (v2 != null && v1 != null)
			{
				v1.AddEdge(v2, weight);
				// v2.AddEdge(v1, weight);
			}
		}

		private void ResetUsed()
		{
			foreach (var node in Vertices)
			{
				node.Used = false;
			}
		}
		
		// Обход в ширину (волновой)
		public void widthTraversal()
		{
			ResetUsed();
			var wave = new Queue<Node>();
			
			wave.Enqueue(Vertices[0]);

			while (wave.Count != 0)
			{
				var curNode = wave.Dequeue();
				if (!curNode.Used)
				{
					Console.Write($"{curNode} - ");
				}
				curNode.Used = true;
				
				for (int i = 0; i < curNode.Edges.Count; i++)
				{
					if (!curNode.Edges[i].Node.Used)
					{
						wave.Enqueue(curNode.Edges[i].Node);
					}
				}
			}
			Console.Write("end");
			Console.WriteLine();
		}
		
		// Обход в глубину (волновой)
		public void depthTraversal()
		{
			ResetUsed();
			var buffer = new Stack<Node>();
			
			buffer.Push(Vertices[0]);

			while (buffer.Count != 0)
			{
				var curNode = buffer.Pop();
				if (!curNode.Used)
				{
					Console.Write($"{curNode} - ");
				}
				curNode.Used = true;
				
				for (int i = 0; i < curNode.Edges.Count; i++)
				{
					if (!curNode.Edges[i].Node.Used)
					{
						buffer.Push(curNode.Edges[i].Node);
					}
				}
			}
			Console.Write("end");
			Console.WriteLine();
		}
    }
}