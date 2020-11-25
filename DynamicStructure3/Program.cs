using System;
using System.Collections.Generic;

namespace DynamicStructure3
{
    class Program
    {
        static void Main(string[] args)
        {
            string seq1 = "()(){([])}";
            CheckSeq(seq1);

            string seq2 = "()){(]}";
            CheckSeq(seq2);

            Console.ReadKey();
        }

        public static void CheckSeq(string seq) 
        {
            MyStack<char> myStack = new MyStack<char>();
            MyStack<char> temp = new MyStack<char>();
            string CheckSymbol = "(){}[]";
            foreach (var item in seq)
            {
                if (CheckSymbol.Contains(item))
                {
                    myStack.Push(item);
                }      
            }

            while(myStack.Count>0)
            {
                if (temp.Count == 0)
                {
                    temp.Push(myStack.Pop());
                }
                else
                {
                    if (myStack.Peek() == ')' && temp.Peek() == '(')
                    {
                        temp.Pop();
                        myStack.Pop();
                    }
                    else if (myStack.Peek() == '}' && temp.Peek() == '{')
                    {
                        temp.Pop();
                        myStack.Pop();
                    }
                    else if (myStack.Peek() == '}' && temp.Peek() == '{')
                    {
                        temp.Pop();
                        myStack.Pop();
                    }
                    else if (myStack.Peek() == '(' && temp.Peek() == ')')
                    {
                        temp.Pop();
                        myStack.Pop();
                    }
                    else if (myStack.Peek() == '{' && temp.Peek() == '}')
                    {
                        temp.Pop();
                        myStack.Pop();
                    }
                    else if (myStack.Peek() == '[' && temp.Peek() == ']')
                    {
                        temp.Pop();
                        myStack.Pop();
                    }
                    else
                    {
                        temp.Push(myStack.Pop());
                    }
                    
                }
            }


            Console.WriteLine($"следовательность: {seq}");

            if (temp.Count == 0 && myStack.Count == 0)
            {    
                Console.WriteLine("Последовательность верна.");
            }
            else
            {
                Console.WriteLine("Последовательност ошибочна.");
            }
        }

      
    }
}
