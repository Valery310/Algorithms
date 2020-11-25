using System;
using System.Collections.Generic;

namespace DynamicStructure3
{
    class Program
    {
        static void Main(string[] args)
        {
            DecToBin();
            BinToDec();
            Console.ReadKey();
        }

        static void DecToBin() 
        {
            int x = 250; // число для перевода
            Console.WriteLine(x);
            var stack = new Stack<int>();
            while (x > 0)
            {
                stack.Push(x % 2);
                x /= 2;
            }
            foreach (int i in stack)
                Console.Write(i);
        }

        static void BinToDec()
        {
            string x = "10010"; // число для перевода
            Console.WriteLine(x);
            var stack = new Stack<int>();
            foreach (char item in x)
            {
                stack.Push(Convert.ToInt32(item));
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
