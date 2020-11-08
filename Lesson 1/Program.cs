using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List <Number> arr = Fill(100000000);
            Node groups = new Node();
            groups.Distrib(arr);
            stopwatch.Stop();
            groups.WriteResult();

            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        public struct Number 
        {
            public bool Simple;
            public long Num;
        }

        public struct Groups
        {
            public int Group;
            public List<Number> Arr;

            public void Add(int g, long i) 
            {
                Group = g;
                Arr.Add(i);
            }
        }
        

        static List<Number> Fill(long length) 
        {
            List<Number> arr = new List<Number>((int)length);
            for (int i = 0; i < length; i++)
            {
                arr.Add(new Number() {Simple = false, Num = i + 1} );
            }
            return arr;
        }

        struct Node 
        {
            public List<Groups> arr;
            private List<long> simpleNumbers;

            public void Distrib(List<Number> array)
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

                Stopwatch stopwatch1 = new Stopwatch();
                stopwatch1.Start();
                for (int i = 0; i < array.Count; i++)
                {
                    this.Add(array[i]);
                }
                stopwatch1.Stop();
                TimeSpan ts1 = stopwatch1.Elapsed;
                string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts1.Hours, ts1.Minutes, ts1.Seconds,
                ts1.Milliseconds / 10);
                Console.WriteLine("Add " + elapsedTime1);
            }

            private List<Number> GetAllSimpleNumber(List<Number> array) 
            {
                simpleNumbers = new List<long>(array);
                List<long> tempArr = new List<long>(array);
                List<long> compArr = new List<long>(array.Count);

                List<long> indexArr = new List<long>(array.Count);

                Add(1, 1);
                simpleNumbers.RemoveAt(0);

                long p = 1;
                int step = 0;
                for (int i = 1; i < array.Count; i++)
                {
                    step = 2;
                    p = array[i];

                    for (long index = (p * step) - 1; index < array.Count; index = (p * step) - 1)
                    {
                       // if (array[i] > p)
                       // {


                            //  step = 2;
                            //  int index = p * step - 1;


                       //     while (index < array.Count)
                        //    {
                                if (!compArr.Contains(tempArr[(int)index]))
                                {
                                    compArr.Add(tempArr[(int)index]);
                                    indexArr.Add(index);
                                    // simpleNumbers.Remove(tempArr[index]);
                                }
                                step++;
                        //        index = (p * step) - 1;
                       //     }
                       // }
                    }

                   
                }
                indexArr.Sort();
                for (int i = indexArr.Count - 1; i >= 0; i--)
                {
                  //  Console.WriteLine(indexArr[i]);
                    simpleNumbers.RemoveAt((int)(indexArr[i] - 1));
                }
                foreach (var item in simpleNumbers)
                {
                        Add(2, item);           
                }
                
                return compArr;
            }

            private void Add(int g, long i)
            {
                if (arr == null)
                {
                    arr = new List<Groups>();
                }
                int existgroups = arr.Count;
                if (existgroups < g)
                {
                    for (int n = arr.Count; n < g; n++)
                    {
                        arr.Add(new Groups() {Group = (int)(n + 1), Arr = new List<long>() });
                    }
                }
                arr[g - 1].Add(g, i);
            }

            public void Add(long i)
            {
                    int indexDivider = 0;
                    long divider = simpleNumbers[indexDivider];
                    long dividend = i;
                    int g = 1;
                    while (divider <= dividend)
                    {
                        divider = simpleNumbers[indexDivider];
                        if (dividend % divider == 0)
                        {
                            dividend = dividend / divider;
                            g++;
                        }
                        else
                        {
                            indexDivider++;           
                        }
                    }

                if (g == 1)
                {
                    g = 2;
                }
                    Add(g, i);
            }

            public void WriteResult() 
            {             
                foreach (var item in arr)
                {
                    Console.WriteLine($"Группа {item.Group} содержит {item.Arr.Count} записей.");

                    //foreach (var i in item.Arr)
                    //{
                    //    Console.Write($"{i}, ");
                    //}
                    //Console.WriteLine($"");
                }
            }
        }
    }
}
