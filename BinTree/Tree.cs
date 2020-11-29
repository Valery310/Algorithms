using System;
using System.Collections.Generic;
using System.Text;

namespace BinTree
{
    public class Tree
    {
        private Node RootNode;
        public int Count { get; private set; }

        public Tree() 
        {
            Count = 0;
        }

        public void Add(int value) 
        {
            if (RootNode != null)
            {
                AddNode(value, RootNode);
            }
            else
            {
                RootNode = new Node() { data = value };
            }
            
            Count++;
        }

        private void AddNode(int value, Node node) 
        {
            if (node.data != value)
            {
                if (value < node.data)
                {
                    if (node.left != null)
                    {
                        AddNode(value, node.left);
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
                        AddNode(value, node.right);
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
            Console.WriteLine("Обход КЛП: ");
            KLP(RootNode);
            Console.WriteLine();
            Console.WriteLine("Обход ЛКП: ");
            LKP(RootNode);
            Console.WriteLine();
            Console.WriteLine("Обход ЛПК: ");
            LPK(RootNode);
            Console.WriteLine();
        }

        private void KLP(Node root) 
        {
            if (root != null)
            {
                Console.Write($"{root.data}");
                Console.Write("(");

                if (root.left != null)
                { 
                    KLP(root.left); 
                }
                else
                { 
                    Console.Write("NULL"); 
                }

                    Console.Write(",");

                if (root.right != null)
                { 
                    KLP(root.right); 
                }
                else
                { 
                    Console.Write("NULL"); 
                }

                    Console.Write(")");
            }
        }

        private void LKP(Node root) 
        {
            if (root != null)
            {
                Console.Write("(");

                if (root.left != null)
                {
                    LKP(root.left);
                }
                else
                {
                    Console.Write("NULL");
                }              

                Console.Write("<-");
                Console.Write($"{root.data}");
                Console.Write("->");

                if (root.right != null)
                {
                    LKP(root.right);
                }
                else
                {
                    Console.Write("NULL");
                }
                
                Console.Write(")");
            }
        }
        private void LPK(Node root) 
        {
            if (root != null)
            {
                Console.Write("(");
                if (root.left != null)
                {
                    LPK(root.left);
                }
                else
                {
                    Console.Write("NULL");
                }

                if (root.right != null)
                {
                    LPK(root.right);
                }
                else
                {
                    Console.Write("NULL");
                }
                Console.Write(")");
                Console.Write("->");
                Console.Write($"{root.data}");
            }
        }

        public void Find(int value) 
        {
            Node node = FindNode(value, RootNode);
            if (node != null)
            {
                Console.WriteLine($"Значение {node.data} найдено в дереве.");
            }
            else
            {
                Console.WriteLine($"Значение {value} отсутствует в дереве.");
            }
        }

        private Node FindNode(int value, Node root) 
        {
            if (root != null)
            {
                Node temp = null;
                if (root.data == value)
                {
                    return root;
                }
                else if (value < root.data)
                {
                        temp = FindNode(value, root.left);                
                }
                else
                {
                    if (temp == null)
                    {
                        temp = FindNode(value, root.right);
                    }           
                }
                return temp;
            }
            else
            {
                return null;
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
}
