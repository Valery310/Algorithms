using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начался подсчет...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int lenght = 1_500_000_000;
            Number [] arr = Fill(lenght);//Заполнение массива
            Console.WriteLine($"Создан массив длинной {lenght}");
            Node.Distrib(arr);//Обработка чисел массива

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("Распределение по групам заняло " + elapsedTime);

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            Node.WriteResult(arr);

            stopwatch1.Stop();
            TimeSpan ts1 = stopwatch1.Elapsed;
            string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts1.Hours, ts1.Minutes, ts1.Seconds,
            ts1.Milliseconds / 10);
            
            Console.WriteLine("Подготовка вывода информации заняла " + elapsedTime1);
                 
        }

        public struct Number 
        {
            public byte Group;
            public int Num;
        }

        public struct Groups
        {
            public byte Group;
            public List<Number> Arr;

            public void Add(byte g, Number i) 
            {
                Group = g;
                Arr.Add(i);
            }
        }
        

        static Number [] Fill(int length) 
        {
            Number [] arr = new Number[length];
            for (int i = 0; i < length; i++)
            {
                arr[i].Num = i + 1;
                arr[i].Group = 2;
            }
            return arr;
        }

        static class Node
        {

            public static void Distrib(Number [] array)
            {
                Number SourceNumber;

                array[0].Group = 1;

                int step = 0;
                double pow = 0;

                for (int i = 1; i < array.Length; i++)
                {
                    step = 1;
                    SourceNumber = array[i];

                    for (int index = SourceNumber.Num - 1; index < array.Length && index >= 0; index = (SourceNumber.Num * step) - 1)
                    {
                        if (array[index].Group == SourceNumber.Group && array[index].Num != SourceNumber.Num)
                        {
                            pow = Math.Log(array[index].Num, SourceNumber.Num);
                            if (pow - Math.Floor(pow) == 0)
                            {
                                array[index].Group = (byte)(SourceNumber.Group + (int)pow - 1);
                            }
                            else
                            {
                                array[index].Group++;
                            }
                        }
                        step++;
                    }
                }

                Console.WriteLine("Подсчет завершен.");   
            }
          
            public static void WriteResult(Number [] arr)
            {
                List<Groups> group = new List<Groups>();
                foreach (var item in arr)
                {
                    Groups g = group.Find(c => c.Group == item.Group);
                    if (g.Arr == null)
                    {
                        Groups newGroup = new Groups() { Group = item.Group, Arr = new List<Number>() };
                        g = newGroup;
                        group.Add(newGroup);
                    }
                    g.Arr.Add(new Number() { Num = item.Num, Group = item.Group });
                }
                

                foreach (var item in group)
                {

                    Console.WriteLine($"Группа {item.Group} содержит {item.Arr.Count} записей.");

                    //foreach (var i in item.Arr)
                    //{
                    //    Console.Write($"{i.Num}, ");
                    //}
                    //Console.WriteLine($"");
                }
            }
        }
    }
}
