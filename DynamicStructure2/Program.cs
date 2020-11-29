using System;
using System.Collections.Generic;

namespace DynamicStructure2
{
    class Program
    {
        //2. Добавить в программу «реализация стека на основе односвязного списка» проверку на выделение памяти.Если память не выделяется, то выводится соответствующее сообщение. Постарайтесь создать ситуацию, когда память не будет выделяться (добавлением большого количества данных).
        //    КрюковВН
        static void Main(string[] args)
        {
            Console.WriteLine("Начинаю заполнять стек.");
            FillStack();
            Console.ReadKey();
        }

        public static void FillStack() 
        {
            MyStack<long> myStack = new MyStack<long>();

            for (long i = 0; i < 5_000_000_000; i++)
            {
                myStack.Push(i);
            }

            for (long i = 0; i < 5_000; i++)
            {
                Console.Write($"{myStack.Pop()}, ");
            }

        }

    }

}
