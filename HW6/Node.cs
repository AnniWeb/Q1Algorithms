using System.Collections.Generic;

namespace HW6
{
    public class Node //Вершина
    {
        public bool Used { get; set; }
        public string Name { get; }
        public List<Edge> Edges { get; } //исходящие связи

        public Node(string name)
        {
	        Edges = new List<Edge>();
	        Name = name;
	        Used = false;
        }
	
		public void AddEdge(Edge newEdge)
		{
			Edges.Add(newEdge);
		}
		
		public void AddEdge(Node vertex, int edgeWeight)
		{
			AddEdge(new Edge{Node = vertex, Weight = edgeWeight});
		}

		public override string ToString() => Name;
    }
}