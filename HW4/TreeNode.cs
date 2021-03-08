namespace HW4
{
    public class TreeNode
	{
		public int Value { get; set; }
		public TreeNode LeftChild { get; set; }
		public TreeNode RightChild { get; set; }
		
		public TreeNode Parent { get; set; }
		
		public int Depth { get; set; }
		
		public override bool Equals(object obj)
		{
			var node = obj as TreeNode;

			if (node == null)
				return false;

			return node.Value == Value;
		}
	}
    
    // Для себя, чтобы не забыть синтаксис
    
 //    public class TreeNode<T>
	// {
	// 	public T Value { get; set; }
	// 	public TreeNode<T> LeftChild { get; set; }
	// 	public TreeNode<T> RightChild { get; set; }
	// 	public TreeNode<T> Parent { get; set; }
	// }
	
	// var node = new TreeNode<int>;
	
}