using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Matrix
{
    public static class Graph
    {
        public static int[,] Matrix { get; private set; }
        public static Vertex[] vertices { get; private set; }

        public static void ReadMatrix()
        {
            string path = $"{AppContext.BaseDirectory}matrix.txt";
            string[] value;

            if (File.Exists(path))
            {
                string[] Text = File.ReadAllLines(path);
                if (Text.Length != 0 && Text.Where(x => x.Length == 0).Count() == 0)
                {
                    value = Text[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
                    Matrix = new int[Text.Length, value.Length];
                    vertices = new Vertex[Text.Length];

                    for (int i = 0; i < Text.Length; i++)
                    {
                        value = Text[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
                        vertices[i] = new Vertex(new int[value.Length]);

                        for (int b = 0; b < value.Length; b++)
                        {
                            Matrix[i, b] = int.Parse(value[b]);
                            vertices[i].Edge[b] =  int.Parse(value[b]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Матрица смежности пуста.");
                }
            }
            else
            {
                Console.WriteLine("Файл матрицы смежности не найден.");
            }
        }

        public static void WidthTraversal(int index)
        {
            Queue<Vertex> queueNodes = new Queue<Vertex>();
            Vertex Temp = vertices[index];
            Temp.Status = 2;
            queueNodes.Enqueue(vertices[index]);

            while(queueNodes.Count > 0)
            {
                Temp = queueNodes.Dequeue();
                if (Temp.Status == 2)
                {
                    for (int i = 0; i < Temp.Edge.Length; i++)
                    {
                        if (Temp.Edge[i] == 1)
                        {
                            Temp.Value = 200;//какая-то полезная работа
                            if (vertices[i].Status == 1)
                            {
                                vertices[i].Status = 2;                              
                                queueNodes.Enqueue(vertices[i]);
                            }                            
                        }
                    }
                }              
            }
        }

        public static void DepthTraversal(Vertex vertex, int p)
        { 
            if (!vertex.Key)
            {
                vertex.Value = 30;//какая-то полезная работа
                vertex.Key = true;

                for (int i = 0; i < vertex.Edge.Length; i++)
                {
                    if (vertex.Edge[i] == 1)
                    {
                        if (!vertices[i].Key)
                        {                          
                            DepthTraversal(vertices[i], p++);
                        }
                    }
                }
            }
        }

        public static void OutputMatrix()
        {
            char v = 'A';
            char h = 'A';
            int length = Matrix.Length / Matrix.GetLength(1);
            Console.Write(" ");

            for (int i = 0; i < length; i++)
            {
                Console.Write($" {h}");
                h++;
            }

            Console.WriteLine();

            for (int i = 0; i < length; i++)
            {
                Console.Write($"{v} ");
                v++;
                for (int b = 0; b < Matrix.GetLength(1); b++)
                {
                    Console.Write($"{Matrix[i, b]} ");
                }
                Console.WriteLine();
            }
        }

        public static void OutputValue()
        {
            char v = 'A';
            char h = 'A';
            Console.Write(" ");

            for (int i = 0; i < vertices.Length; i++)
            {
                Console.Write($" {h}");
                h++;
            }

            Console.WriteLine();

            for (int i = 0; i < vertices.Length; i++)
            {
                Console.Write($"{v} ");
                v++;
                for (int b = 0; b < vertices[i].Edge.Length; b++)
                {
                    Console.Write($"{vertices[i].Value} ");
                }
                Console.WriteLine();
            }
        }


        public class Vertex
        {
            public int Status { get; set; }
            public int[] Edge { get; set; }
            public int Value { get; set; }
            public bool Key { get; set; }

            public Vertex(int [] edge)
            {
                Status = 1;
                Edge = edge; 
            }
        }
    }
}
