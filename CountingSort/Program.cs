using System;
using System.Diagnostics;

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

        private static int[] values1;
        private static int[] values2;
        private static int[] values3;

        static void Main(string[] args)
        {
            Start();           
        }

        private static void Start() 
        {
            Console.WriteLine("Выполняется генерация тестовых данных...");
            values1 = GenerateArray(1_000);
            values2 = GenerateArray(100_000);
            values3 = GenerateArray(1000_000_000);

            bool _continue = true;
            while (_continue)
            {
                Console.WriteLine("Выберите действие:\n 1 - Пересоздать массив тестовых данных.\n 2 - Сортировка подсчетом\n 3 - Быстрая сортировка\n 0 - Для выхода из программы.");
                string typeOfSort = Console.ReadLine();
                _continue = StartSelectedSort(typeOfSort);
            }          
        }

        private static bool StartSelectedSort(string typeOfSort)
        {
            Sorting sorting;
            bool _continue;

            switch (typeOfSort)
            {
                case "1":
                    Console.WriteLine("Генерация значений массивов начата.");
                    values1 = GenerateArray(1_000);
                    values2 = GenerateArray(100_000);
                    values3 = GenerateArray(1000_000_000);                    
                    return true;
                case "2":
                    sorting = CountingSort;//присваиваем делегату метод сортировки
                    Console.WriteLine("Выбрана сортировка подсчетом.");
                    _continue = true;
                    break;
                case "3":
                    sorting = Quicksort;
                    Console.WriteLine("Выбрана быстрая сортировка.");
                    _continue = true;
                    break;
                case "0":
                    return false;
                default:
                    Console.WriteLine("Введите значение из предложенного диапазона.");
                    return true;
            }

            Sort(values1, sorting);//Выполняем сортировку с тремя разными наборами тестовых данных.
            Sort(values2, sorting);
            Sort(values3, sorting);

            return _continue;
        }

        private static int[] GenerateArray(int v)   //Генерация тестовых данных. Для разных типов сортировок используются одни и те же данные. Это позволит сравнить скорость выполнения сортировки разными алгоритмами.
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int[] values = new int[v];

            for (int i = 0; i < v; i++)
            {
                values[i] = random.Next(0, 1000);//Массив заполняется случайными данными.
            }

            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine($"Генерация {values.Length} значений  заняла: {elapsedTime}\n");

            return values;
        }

        public delegate void Sorting(int [] values);//используем делегат, чтобы не повторять код

        private static void Sort(int[] values, Sorting sorting)// В этот метод передается массив данных и делегат меттода сортировки
        {
            Stopwatch stopwatch = new Stopwatch();//Подсчет времени выполнения алгоритм сортировки

            stopwatch.Start();

            sorting(values);//Вызов алгоритма сортировки

            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine($"Сортировка {values.Length} значений  заняла: {elapsedTime}\n");
        }

        private static void CountingSort(int[] values) //Сортировка подсчетом
        {
            int[] temp = new int[1000+1]; //вспомогательный массив для подсчета количества значений. По-умолчанию все значения равны нулю.

            for (var i = 0; i < values.Length; i++)//Проходим весь массив данных и прибавляем значение впомогательного массива по индексу входящих данных. Индексы ужже расположены по порядку и это позволяет ускорить алгоритм.
            {
                temp[values[i]]++; 
            }

            var index = 0;
            for (var i = 0; i < temp.Length; i++)//проходим по всем значениям вспомогательного массива и по порядку распологаем их во входящем массиве. 
            {
                for (var j = 0; j < temp[i]; j++)//числа могут повторяться и распологаться они должны друг за другом.
                {
                    values[index] = i;
                    index++;
                }
            }
        }

        private static void Quicksort(int[] values) 
        {
            _Quicksort(values, 0, values.Length - 1);//Передаем в  рекурсивный метод массив данных, индекс начала сортируемого отрезка и индекс окончания сортируемого отрезка.
        }

        private static void _Quicksort(int[] values, int start, int end)
        {
            int i = start, j = end, x = values[(start + end) / 2];//выбираемм начальное значение, конечное значение индекса и разделяемое значение
            do
            {
                while (values[i] < x)//проходим по каждому элементу слева направо и сдвигаем указатель вправо, если значение меньше разделяемого значения.
                    i++;

                while (values[j] > x)//проходим по каждому элементу спрва налево и сдвигаем указатель влево, если значение больше разделяемого значения.
                    j--;

                if (i <= j)
                {
                    if (values[i] > values[j])//Меняем местами значения, если левый указатель меньше или равен правому, а так же если левое значение сортируемого отрезка больше правого значения этого отрезка.
                    {
                        int temp = values[i];
                        values[i] = values[j];
                        values[j] = temp;
                    }
                    
                    i++;
                    j--;
                }
            } while (i <= j);//Проходим по элементам пока указатели не начнут указывать на один и тот же элемент отрезка массива.
            if (i < end)//определяем левый ли отрезок или правый.
                _Quicksort(values, i, end);//вызываем сортировку нового отрезка массива
            if (start < j)
                _Quicksort(values, start, j);
        }
    }
}
