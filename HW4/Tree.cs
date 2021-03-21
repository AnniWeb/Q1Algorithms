using System;
using System.Collections;
using System.Collections.Generic;

namespace HW4
{
    public class Tree : ITree
    {
        private TreeNode _root;

        public TreeNode Root
        {
            get => _root;
            private set => _root = value;
        }

        public Tree(TreeNode root)
        {
            Root = root;
        }

        public void AddItem (int value)
        {
            TreeNode tmp = null;
            int depth = 0;

            if (_root == null)
            {
                _root = GetFreeNode(value, null);
                return;
            }

            tmp = _root;
            while (tmp != null)
            {
                if (value == tmp.Value)
                {
                    break;
                }
                depth++;

                if (value > tmp.Value)
                {
                    if (tmp.RightChild != null)
                    {
                        tmp = tmp.RightChild;
                        continue;
                    }
                    else
                    {
                        tmp.RightChild = GetFreeNode(value, tmp);
                        return;
                    }
                }
                else
                {
                    if (tmp.LeftChild != null)
                    {
                        tmp = tmp.LeftChild;
                        continue;
                    }
                    else
                    {
                        tmp.LeftChild = GetFreeNode(value, tmp);
                        return;
                    }
                }
            }
        }

        // Поиск узла
        public TreeNode GetNodeByValue (int value)
        {
            var tmp = _root;
            while (tmp != null)
            {
                if (value == tmp.Value)
                {
                    return tmp;
                }

                if (value > tmp.Value)
                {
                    if (tmp.RightChild != null)
                    {
                        tmp = tmp.RightChild;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (tmp.LeftChild != null)
                    {
                        tmp = tmp.LeftChild;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return null;
        }

        // Удаление узла
        private void RemoveNode(TreeNode node)
        {
            var parent = node.Parent;
            // Оба дочерних узла пустые
            if (node.LeftChild == null && node.RightChild == null)
            {
                if (node == _root)
                {
                    _root = null;
                }
                else
                {
                    if (parent.LeftChild == node)
                    {
                        parent.LeftChild = null;
                    }
                    if (parent.RightChild == node)
                    {
                        parent.RightChild = null;
                    }
                }
                
            }
            // Один из дочерних узлов пустой
            else if (node.LeftChild == null || node.RightChild == null)
            {
                if (node == _root)
                {
                    if (node.LeftChild == null)
                    {
                        _root = node.RightChild;
                    }

                    if (node.RightChild == null)
                    {
                        _root = node.LeftChild;
                    }

                    _root.Parent = null;
                    RecalcDepth(_root);
                }
                else
                {
                    if (node.LeftChild == null)
                    {
                        if (parent.LeftChild == node)
                        {
                            parent.LeftChild = node.RightChild;
                            
                            RecalcDepth(parent.LeftChild);
                        }
                        else
                        {
                            parent.RightChild = node.RightChild;
                            
                            RecalcDepth(parent.RightChild);
                        }

                        node.RightChild.Parent = parent;
                    }

                    if (node.RightChild == null)
                    {
                        if (parent.LeftChild == node)
                        {
                            parent.LeftChild = node.LeftChild;
                            RecalcDepth(parent.LeftChild);
                        }
                        else
                        {
                            parent.RightChild = node.LeftChild;
                            RecalcDepth(parent.RightChild);
                        }

                        node.LeftChild.Parent = parent;
                    }
                }
            }
            // Оба дочерних узла не пустые
            else
            {
                var nextNode = GetNextNode(node);
                node.Value = nextNode.Value;
                if (nextNode.Parent.LeftChild == nextNode)
                {
                    nextNode.Parent.LeftChild = nextNode.RightChild;
                    if (nextNode.RightChild != null)
                    {
                        nextNode.RightChild.Parent = nextNode.Parent;
                    }
                }
                else
                {
                    nextNode.Parent.RightChild = nextNode.RightChild;
                    if (nextNode.RightChild != null)
                    {
                        nextNode.RightChild.Parent = nextNode.Parent;
                    }
                }
            }
        }
        
        public void RemoveItem (int value)
        {
            var findNode = GetNodeByValue(value);
            if (findNode != null)
            {
                RemoveNode(findNode);
            }
        }

		
        public TreeNode GetRoot()
        {
            return _root;
        }

        // Обход в ширину
        private List<TreeNode> widthTraversal()
        {
            var buffer = new Queue<TreeNode>();
            var returnArray = new List<TreeNode>();
            if (_root == null)
            {
                return returnArray;
            }
            buffer.Enqueue(_root);

            while (buffer.Count != 0)
            {
                var curNode = buffer.Dequeue();
                returnArray.Add(curNode);

                var depth = curNode.Depth + 1;
                
                
                if (curNode.LeftChild != null)
                {
                    buffer.Enqueue(curNode.LeftChild);
                }
                if (curNode.RightChild != null)
                {
                    buffer.Enqueue(curNode.RightChild);
                }
            }

            return returnArray;
        }
        
        // Обход в глубину
        private List<TreeNode> depthTraversal()
        {
            var buffer = new Stack<TreeNode>();
            var returnArray = new List<TreeNode>();
            if (_root == null)
            {
                return returnArray;
            }
            buffer.Push(_root);

            while (buffer.Count != 0)
            {
                var curNode = buffer.Pop();
                returnArray.Add(curNode);

                var depth = curNode.Depth + 1;
                
                if (curNode.RightChild != null)
                {
                    buffer.Push(curNode.RightChild);
                }
                
                if (curNode.LeftChild != null)
                {
                    buffer.Push(curNode.LeftChild);
                }
            }

            return returnArray;
        }
        
        public void PrintTree()
        {
            var nodesDepthTraversal = depthTraversal();

            if (nodesDepthTraversal.Count == 0)
            {
                Console.WriteLine("Пустое дерево");
            }
            
            for (int i = 0; i < nodesDepthTraversal.Count; i++)
            {
                // Console.WriteLine($"{nodesDepthTraversal[i].Value} - {nodesDepthTraversal[i].Depth}");
                var sep = new string(' ', 5 * nodesDepthTraversal[i].Depth);
                var mod = $"D{nodesDepthTraversal[i].Depth} - " 
                          + (nodesDepthTraversal[i].Parent != null && nodesDepthTraversal[i].Parent.RightChild != null 
                            && nodesDepthTraversal[i].Parent.RightChild == nodesDepthTraversal[i] ? "R" : "L");
                Console.WriteLine($"{sep}[{mod}] {nodesDepthTraversal[i].Value}");
            }
            Console.WriteLine();
        }

        // Балансировка дерева
        private void Balance()
        {
            
        }

        private void RecalcDepth(TreeNode root)
        {
            var buffer = new Queue<TreeNode>();
            buffer.Enqueue(root);

            while (buffer.Count != 0)
            {
                var curNode = buffer.Dequeue();

                curNode.Depth--;

                if (curNode.LeftChild != null)
                {
                    buffer.Enqueue(curNode.LeftChild);
                }
                if (curNode.RightChild != null)
                {
                    buffer.Enqueue(curNode.RightChild);
                }
            }
        }
        
        // Генерация узла
        private TreeNode GetFreeNode(int value, TreeNode parent)
        {
            return new TreeNode { Value = value, Depth = parent != null ? parent.Depth+1 : 0, Parent = parent};
        }

        // Минимальное значение в поддереве
        private TreeNode GetMinNode(TreeNode curNode)
        {
            if (curNode.LeftChild == null)
            {
                return curNode;
            }

            return GetMinNode(curNode.LeftChild);
        }
        
        // Максимальное значение в поддереве
        private TreeNode GetMaxNode(TreeNode curNode)
        {
            if (curNode.RightChild == null)
            {
                return curNode;
            }

            return GetMaxNode(curNode.RightChild);
        }
        
        // Получение узла со следующим значением
        private TreeNode GetNextNode(TreeNode curNode)
        {
            if (curNode.RightChild != null)
            {
                return GetMinNode(curNode.RightChild);
            }

            var tmp = curNode;
            var nextNode = curNode.Parent;

            while (nextNode != null && curNode == tmp.RightChild)
            {
                nextNode = tmp;
                tmp = tmp.Parent;
            }

            return nextNode;
        }
    }
}