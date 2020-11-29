using System;

namespace BinTree
{
    class Program
    {
        //2. Переписать программу, реализующую двоичное дерево поиска.
        //а) Добавить в него обход дерева различными способами;
        //б) Реализовать поиск в двоичном дереве поиска;
        //в) *Добавить в программу обработку командной строки, с помощью которой можно указывать, из какого файла считывать данные, каким образом обходить дерево.
        //    КрюковВН
        static void Main(string[] args)
        {
            Tree tree = new Tree(TypeTree.Binary);
            tree.AddNode(10);
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                tree.AddNode(random.Next(0, 50));
            }
            tree.Write();
            Console.ReadLine();
        }
    }
}
