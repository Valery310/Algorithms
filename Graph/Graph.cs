using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Graph
    {
        public Node RootNode { get; set; }
        int Count { get; set; }
        public List<Node> Vertex { get; set; }

        public int[,] Matrix { get; set; }

        public Graph()
        {
            Count = 0;
            Vertex = new List<Node>();
        }

        public void AddVertex(Node node)
        {
            if (!Vertex.Contains(node))
            {
                Vertex.Add(node);
            }
        }

        public void AddVertex(Node node, Edge edge)
        {
            if (!Vertex.Contains(node))
            {
                if (!node.Path.Contains(edge))
                {
                    node.Path.Add(edge);
                }
                Vertex.Add(node);
            }
        }

        public void AddVertex(Node node, List<Edge> edges)
        {
            if (!Vertex.Contains(node))
            {
                node.Path = edges;
                Vertex.Add(node);
            }
        }

        public void AddEdge(Edge edge, Node node)
        {
            if (Vertex.Contains(node))
            {
                if (!node.Path.Contains(edge))
                {
                    node.Path.Add(edge);
                }
            }
        }

        public void AddEdge(List<Edge> edge, Node node)
        {
            if (Vertex.Contains(node))
            {
                node.Path = edge;
            }
        }

        public void SelectRoot(Node node)
        {
            RootNode = node;
        }

        public void WidthTraversal()
        {
            Queue<Node> queueNodes = new Queue<Node>();
            queueNodes.Enqueue(RootNode);

            while(true)
            {
                if (queueNodes.Count == 0)
                {
                    break;
                }
                var n = queueNodes.Dequeue();
                if (n.Status == 2)
                {
                    foreach (var item in n.Path)
                    {
                        if (item.To.Status == 1)
                        {
                            item.To.Status = 2;
                            queueNodes.Enqueue(item.To);
                        }
                    }
                    n.Value = 200; //какая-то полезная работа
                    n.Status = 3;
                }

            }
        }

        public void DepthTraversal()
        {

        }

        public class Node
        {
            public string Name { get; set; }
            public int Value { get; set; }
            public bool Key { get; set; }
            public int Status { get; set; }
            public List<Edge> Path { get; set; }

            public Node()
            {
                Status = 1;
                Path = new List<Edge>();
            }
        }

        public class Edge
        {
            public Node From { get; set; }
            public Node To { get; set; }
            public int Weight { get; set; }
        }
    }
}
