using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubleSort
{

//    1. Попробовать оптимизировать пузырьковую сортировку.Сравнить количество операций сравнения
//оптимизированной и не оптимизированной программы. Написать функции сортировки, которые
//возвращают количество операций.
//2. *Реализовать шейкерную сортировку.
//3. Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный
//массив. Функция возвращает индекс найденного элемента или -1, если элемент не найден.
//4. *Подсчитать количество операций для каждой из сортировок и сравнить его с асимптотической
//сложностью алгоритма.
//КрюковВН
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static List<int> Fill(int length)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < length; i++)
            {
                list.Add(i+1);
            }
            return list;
        }

        public static void BubbleSort(List<int> list) 
        {
        
        }

        public static void OptimizeBubbleSort(List<int> list)
        {

        }

        public static void ShakeSort(List<int> list)
        {

        }

        public static int BinarySearch(List<int> list)
        {

            return -1;
        }
    }
}
