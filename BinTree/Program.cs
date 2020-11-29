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

        public static Random random = new Random();

        static void Main(string[] args)
        {

            FillTree();
            Console.ReadLine();
        }

        public static void FillTree()
        {
            Tree tree = new Tree();
            for (int i = 0; i < 20; i++)
            {
                tree.Add(random.Next(0, 50));
            }
            tree.Write();

            for (int i = 0; i < 5; i++)
            {
                tree.Find(random.Next(0, 50));
            }
        }

    }
}
