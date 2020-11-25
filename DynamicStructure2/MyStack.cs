using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicStructure2
{
    class MyStack<T>
    {
        Node<T> node;
        int Count;

        public MyStack() 
        {
            Count = 0;
            node = null;
        }
          
        unsafe public void Push(T Value)
        {
            try
            {
                long mem = GC.GetTotalMemory(true);
                Node<T> newNode = new Node<T>(Value, node);
                node = newNode;
                Count++;
                mem = GC.GetTotalMemory(true) - mem;
            //    Console.WriteLine($"Выделено {mem} памяти.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                Console.WriteLine("Память не выделена");
            }       
        }

        public T Peek()
        {
            if (node != null)
            {
                return node.Value;
            }
            return default;
        }

        public T Pop()
        {
            if (node != null)
            {
                Count--;
                T temp = node.Value;
                node.Value = default;
                node = node.PrevNode;
                return temp;
            }
            return default;   
        }

        private class Node<T>
        {
            public T Value;
            public Node<T> PrevNode;

            public Node(T _Value, Node<T> _PrevNode)
            {
                Value = _Value;
                PrevNode = _PrevNode;
            }
        }

    }

   


}
