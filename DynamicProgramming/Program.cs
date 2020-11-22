using System;

namespace DynamicProgramming
{

//    1. * Количество маршрутов с препятствиями.Реализовать чтение массива с препятствием и нахождение количество маршрутов.
//Например, карта:
//3 3
//1 1 1
//0 1 0
//0 1 0
//        КрюковВН

    class Program
    {
        static void Main(string[] args)
        {
            GetCountPath();
            Console.ReadLine();
        }

        public static void GetCountPath() 
        {
            int N, M;
            M = 3;
            N = 3;
            Console.WriteLine("Задача 1 - Количество маршрутов с препятствиями");
            int[,] A = new int[N, M];
            int[,] Map = {
                { 1,1,1},
                { 0,1,0},
                { 0,1,0}
            };

            int i, j;
            Console.WriteLine("Карта массива 'Map', где '0' - закрытое поле: ");
            Write(N, M, Map);
            Console.WriteLine("---------------------------\n");

            int first_way = 1;

            for (j = 0; j < M; j++)
            {
                if (Map[0, j] == 0)
                {
                    first_way = 0;
                }

                A[0, j] = first_way;
            }

            first_way = 1;

            for (i = 1; i < N; i++)
            {
                if (Map[i, 0] == 0)
                {
                    first_way = 0;
                }

                A[i, 0] = first_way;

                for (j = 1; j < M; j++)
                {
                    if (Map[i, j] == 0)
                    {
                        A[i, j] = 0;
                    }
                    else
                    {
                        A[i, j] = A[i, j - 1] + A[i - 1, j];
                    }
                }
            }
            Console.WriteLine("Подсчитано количество маршрутов из A[0][0] в каждое открытое поле: ");
            Write(N, M, A);
            Console.WriteLine("---------------------------\n");
        }

        public static void Write(int n, int m, int [,] a)
        {
            int i, j;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write($"{a[i,j]} ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
