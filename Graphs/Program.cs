using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Linq;
using Matrix;

namespace Graphs
{
    class Program
    {
        //1. Написать функции, которые считывают матрицу смежности из файла и выводят ее на экран.
        //2. Написать рекурсивную функцию обхода графа в глубину.
        //3. Написать функцию обхода графа в ширину.
        //КрюковВН
        static void Main(string[] args)
        {
            Graph.ReadMatrix();
            Graph.OutputMatrix();     
            Graph.WidthTraversal(1);
            Graph.OutputValue();
            Graph.DepthTraversal(Graph.vertices[2], 1);
            Graph.OutputValue();

            Console.ReadLine();
        }  
    }
}
