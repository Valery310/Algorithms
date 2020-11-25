using System;
using System.Collections.Generic;

namespace DynamicStructure
{
    //1. Реализовать перевод из десятичной в двоичную систему счисления с использованием стека.
    //   КрюковВН
    class Program
    {
        static void Main(string[] args)
        {
            BinToDec();
            Console.ReadKey();
        }


        static void BinToDec()
        {
            string x = "10010"; // число для перевода
            Console.WriteLine($"Значение для первода в десятичную сс: {x}");
            var stack = new Stack<int>();

            foreach (var item in x)
            {
                stack.Push(Convert.ToInt32(item.ToString()));
            }

            int res = 0;
            int v = 0;
            int i = 0;

            while (stack.TryPop(out v))
            {
                res = res + (int)(v * Math.Pow(2, i));
                i++;
            }

            Console.WriteLine(res);
        }
    }
}
