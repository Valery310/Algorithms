using System;

namespace ComplexSort
{
    class Program
    {
        //1. Реализовать сортировку подсчетом.
        //2. Реализовать быструю сортировку.
        //Проанализировать время работы каждого из вида сортировок для 100, 10000, 1000000 элементов.
        //Если самостоятельно реализовать сортировку не получается, разрешается найти сортировку в Интернете.Желательно прокомментировать строки программы.Записывайте в начало программы условие и свою фамилию. 
        //Все решения создавайте в одной программе. Снабдите программу меню.
        //КрюковВН

        private static Random random = new Random();

        static void Main(string[] args)
        {
            Start();           
        }

        private static void Start() 
        {
            bool _continue = true;
            while (_continue)
            {
                Console.WriteLine("Выберите тип сортирокви:\n 1 - Сортировка подсчетом\n 2 - Быстрая сортировка\n 0 - Для выхода из программы.");
                string typeOfSort = Console.ReadLine();
                _continue = StartSelectedSort(typeOfSort);
            }          
        }

        private static bool StartSelectedSort(string typeOfSort)
        {
            int[] values1 = GenerateArray(100);
            int[] values2 = GenerateArray(10000);
            int[] values3 = GenerateArray(1000000);

            switch (typeOfSort)
            {
                case "1":
                    return true;
                case "2":
                    Quicksort(values1, 0, values1.Length);
                    Quicksort(values2, 0, values2.Length);
                    Quicksort(values3, 0, values3.Length);
                    return true;
                case "0":
                    return false;
                default:
                    Console.WriteLine("Введите значение из предложенного диапазона.");
                    return true;
            }
        }

        private static int[] GenerateArray(int v)
        {
            int[] values = new int[v];

            for (int i = 0; i < v; i++)
            {
                values[i] = random.Next(0, int.MaxValue);
            }

            return values;
        }

        private static void Quicksort(int[] values, int start, int end) 
        {
        
        }
    }
}
