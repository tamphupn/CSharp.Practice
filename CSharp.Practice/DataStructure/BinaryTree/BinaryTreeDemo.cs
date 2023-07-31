using System;
namespace DataStructure.BinaryTree
{
	public class BinaryNode
	{
		public int Data;
		public BinaryNode Left, Right;

		public BinaryNode(int data)
		{
			Data = data;
			Left = Right = null;
		}

		public void AddNode(BinaryNode newNode)
		{
			if ()
		}

		public int CalcLeafNode(BinaryNode node)
		{
			if (node == null)
			{
				return 0;
			}

			if (node.Left == null && node.Right == null)
			{
				return 1;
			}

			return CalcLeafNode(node.Left) + CalcLeafNode(node.Right);
		}

		public int CalcDepth(BinaryNode node)
		{
			if (node == null)
			{
				return -1;
			}

			int leftDepth = CalcDepth(node.Left);
			int rightDepth = CalcDepth(node.Right);

			if (leftDepth > rightDepth)
				return leftDepth + 1;

			return rightDepth + 1;
		}

		public void Travel(BinaryNode node)
		{
			Stack<BinaryNode> nodeStack = new Stack<BinaryNode>();

			if (node == null)
				return;

			nodeStack.Push(node);

			while (nodeStack.Count > 0)
			{
				var topNode = nodeStack.Peek();
				Console.WriteLine($@"Node {topNode.Data}");
				nodeStack.Pop();

				if (topNode.Right != null)
				{
					nodeStack.Push(topNode.Right);
				}
				if (topNode.Left != null)
				{
					nodeStack.Push(topNode.Left);
				}
			}
		}

		public void TravelRecursion(BinaryNode node)
		{
			if (node == null)
				return;

			Console.WriteLine($@"Node {node.Data}");

            if (node.Right != null)
            {
                TravelRecursion(node.Right);
            }

            if (node.Left != null)
			{
				TravelRecursion(node.Left);
			}
		}
	}


	public class BinaryTreeDemo
	{
		public static void InitTree()
		{
			BinaryNode node = new BinaryNode();
			List<int> datas = new List<int>();
			foreach (var data in datas)
			{
				node.ad
			}
		}
	}
}

