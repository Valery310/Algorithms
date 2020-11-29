using System;
using System.Collections.Generic;
using System.Text;

namespace BinTree
{
    public class Tree
    {
        private Node RootNode;
        public int Count { get; private set; }
        public TypeTree Type { get; private set; }

        public Tree(TypeTree tt) 
        {
            RootNode = new Node();
            Count = 0;
            Type = tt;
        }

        public void AddNode(int value) 
        {
            switch (Type)
            {
                case TypeTree.Binary:
                    AddBinary(value, RootNode);
                    break;
                case TypeTree.Balance:
                    AddBalance(value);
                    break;
            }

            Count++;
        }

        private void AddBalance(int value) 
        {
        
        }

        private void AddBinary(int value, Node node) 
        {
            if (node.data != value)
            {
                if (value < node.data)
                {
                    if (node.left != null)
                    {
                        AddBinary(value, node.left);
                    }
                    else
                    {
                        Node temp = new Node() { data = value, root = node };
                        node.left = temp;
                    }
                }
                if (value > node.data)
                {
                    if (node.right != null)
                    {
                        AddBinary(value, node.right);
                    }
                    else
                    {
                        Node temp = new Node() { data = value, root = node };
                        node.right = temp;
                    }
                }
            }
        }

        public void Write() 
        {
            WriteNode(RootNode);
        }

        private void WriteNode(Node root) 
        {
            if (root != null)
            {
                Console.Write($"{root.data}");
                if (root.left != null || root.right != null)
                {
                    Console.Write("(");
                    if (root.left != null)
                        WriteNode(root.left);
                    else
                        Console.Write("NULL");
                    Console.Write(",");
                    if (root.right != null)
                        WriteNode(root.right);
                    else
                        Console.Write("NULL");
                    Console.Write(")");
                }
            }
        }

        public class Node
        {
            public int data;
            public Node left;
            public Node right;
            public Node root;
        }
    }

    public enum TypeTree { Binary, Balance }
}
