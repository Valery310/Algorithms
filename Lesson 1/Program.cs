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

            List<Number> arr = Fill(3000000);//Заполнение массива

            Node.Distrib(arr);//Обработка чисел массива

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);       
            Console.WriteLine("RunTime " + elapsedTime);
        }

        public struct Number 
        {
            public int Group;
            public bool Complex;
            public int Num;
        }

        public struct Groups
        {
            public int Group;
            public List<Number> Arr;

            public void Add(int g, Number i) 
            {
                Group = g;
                Arr.Add(i);
            }
        }
        

        static List<Number> Fill(int length) 
        {
            List<Number> arr = new List<Number>(length);
            for (int i = 0; i < length; i++)
            {
                arr.Add(new Number() {Complex = false, Num = i + 1, Group = 0} );
            }
            return arr;
        }

        static class Node
        {
            private static List<int> simpleNumbers;

            public static void Distrib(List<Number> array)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                array = GetAllSimpleNumber(array);

                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
                Console.WriteLine("GetAllSimpleNumber " + elapsedTime);

                //Stopwatch stopwatch1 = new Stopwatch();
                //stopwatch1.Start();

                //Add(array);

                //stopwatch1.Stop();
                //TimeSpan ts1 = stopwatch1.Elapsed;
                //string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                //ts1.Hours, ts1.Minutes, ts1.Seconds,
                //ts1.Milliseconds / 10);
                //Console.WriteLine("Add " + elapsedTime1);
            }

            private static List<Number> GetAllSimpleNumber(List<Number> array)
            {
                List<Groups> group = new List<Groups>();
                group.Add(new Groups() { Group = 1, Arr = new List<Number>() });
                group[0].Arr.Add(new Number() { Complex = false, Num = 1, Group = 1 });
                group.Add(new Groups() { Group = 2, Arr = new List<Number>() });

                simpleNumbers = new List<int>(100);

                Number tempStruct;
                tempStruct = array[0];
                tempStruct.Complex = false;
                tempStruct.Group = 1;
                array[0] = tempStruct;


                int p = 1;
                int step = 0;

                for (int i = 1; i < array.Count; i++)
                {
                    if (array[i].Complex == false)
                    {
                        step = 2;
                        p = array[i].Num;
                        simpleNumbers.Add(p);
                        group[1].Arr.Add(new Number() { Complex = false, Num = p, Group = 2 });
                        tempStruct = array[i];
                        tempStruct.Group = 2;
                        array[i] = tempStruct;

                        for (int index = (p * step) - 1; index < array.Count && index >= 0; index = (p * step) - 1)
                        {
                            tempStruct = array[index];
                            tempStruct.Complex = true;
                            array[index] = tempStruct;
                            step++;
                        }
                    }
                }
                

                Stopwatch stopwatch1 = new Stopwatch();
                stopwatch1.Start();

                Add(array, group);

                stopwatch1.Stop();
                TimeSpan ts1 = stopwatch1.Elapsed;
                string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts1.Hours, ts1.Minutes, ts1.Seconds,
                ts1.Milliseconds / 10);
                Console.WriteLine("Add " + elapsedTime1);

                return array;
            }

            public static void Add(List<Number> array, List<Groups> group) 
            {
                int dividend = 0;
                int index = 0;
                int divider = 0;
                int result = 0;
                Number tempStruct;
                Number tempStruct1;

                for (int i = 1; i < array.Count; i++)
                {
                    result = 0;
                    index = 0;
                    tempStruct = array[i];
                    
                    if (tempStruct.Complex == true)
                    {
                        dividend = tempStruct.Num;

                        while (true)
                        {                           
                            divider = simpleNumbers[index];

                            if (dividend % divider == 0)
                            {
                                result = dividend / divider;
                                tempStruct1 = array.Find(c => c.Num == result);
                                tempStruct.Group = tempStruct1.Group + 1;

                                //if (tempStruct.Group <= 1)
                                //{
                                //    break;
                                //}
                                //  Groups g = group.Find(c => c.Group == tempStruct1.Group + 1);
                                //  if (g.Arr == null)
                                //  {
                                //      Groups newGroup = new Groups() { Group = tempStruct1.Group + 1, Arr = new List<Number>() };
                                //      g = newGroup;
                                //      group.Add(newGroup);
                                //  }
                                ////  array[index] = tempStruct;
                                //  g.Arr.Add(new Number() { Complex = true, Num = tempStruct.Num, Group = tempStruct.Group });
                                array[i] = tempStruct;
                                break;
                            }
                            else
                            {
                                index++;
                            }
                        }                       
                    }
                }
                Console.WriteLine("Подсчет завершен.");
                WriteResult(array);
            //   WriteResult(group);
            }

            public static void Add(List<Number> array)
            {
                List<Groups> group = new List<Groups>();
                group.Add(new Groups() { Group = 1, Arr = new List<Number>() });
                group[0].Arr.Add(new Number() { Complex = false, Num = 1 });
                group.Add(new Groups() { Group = 2, Arr = new List<Number>() });

                int result = 0;
                int g = 1;

                foreach (var item in simpleNumbers)
                {
                    result = item;
                    g = 2;
                    
                    group[1].Arr.Add(new Number() { Complex = false, Num = item });

                        while (true)
                        {
                            result = result * 2;
                            if (result == 15)
                            {
                                Console.WriteLine("");
                            }
                            if (result > array[array.Count - 1].Num)
                            {
                                break;
                            }
                            else
                            {
                                g++;

                               // var t = group.Find(c => c.Group == g);
                                if (group.Exists(c => c.Group == g))//(t.Arr != null)
                                {
                                    group.Find(c => c.Group == g).Arr.Add(new Number() { Complex = true, Num = result });
                                }
                                else
                                {
                                    group.Add(new Groups() { Group = g, Arr = new List<Number>() });
                                    group.Find(c => c.Group == g).Arr.Add(new Number() { Complex = true, Num = result });
                                }
                            }
                        }
                                   
                }
                WriteResult(group);
            }

            public static void WriteResult(List<Groups> arr)
            {
                foreach (var item in arr)
                {
                    Console.WriteLine($"Группа {item.Group} содержит {item.Arr.Count} записей.");

                    //foreach (var i in item.Arr)
                    //{
                    //    Console.Write($"{i.Num}, ");
                    //}
                    //Console.WriteLine($"");
                }
            }

            public static void WriteResult(List<Number> arr)
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
                    g.Arr.Add(new Number() { Complex = true, Num = item.Num, Group = item.Group });
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
