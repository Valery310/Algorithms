using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator
{
    //3. Исполнитель Калькулятор преобразует целое число, записанное на экране.У исполнителя две команды, каждой команде присвоен номер:
    //Прибавь 1
    //Умножь на 2
    //Первая команда увеличивает число на экране на 1, вторая увеличивает это число в 2 раза.Сколько существует программ, которые число 3 преобразуют в число 20?
    //а) с использованием массива;
    //б) с использованием рекурсии.
    //    Крюков ВН
    class Program
    {
        static void Main(string[] args)
        {
            int Num, Target;
            do
            {
                Console.WriteLine("Введите исходное число: ");
            }
            while (!int.TryParse(Console.ReadLine(), out Num));

            do
            {
                Console.WriteLine("Введите целевое число: ");
            }
            while (!int.TryParse(Console.ReadLine(), out Target));

            int Count = 0;
            GetProgramsCountRec(Num, Target, 0, 0, ref Count);

            Console.WriteLine("CountPathRecursive :" + Count);

            Console.WriteLine("CountPathArray :" + GetProgramsCountArr(Num, Target));


            Console.ReadLine();
        }

        public struct Number
        {
            public int Num;
            public int Path;
        }

        public static int GetProgramsCountArr(int _Num, int Target) 
        {
            Number[] numbers = new Number[Target-(_Num - 1)];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i].Num = i + _Num;
                numbers[i].Path = 0;            }
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].Num == _Num)
                {
                    numbers[i].Path = 1;
                    continue;
                }
                if (numbers[i].Num % 2 == 0 && numbers[i].Num / 2 >= _Num)
                {
                    numbers[i].Path += numbers[i - 1].Path;
                    numbers[i].Path += numbers[Find(numbers[i].Num / 2, numbers)].Path;
                }
                else
                {
                    numbers[i].Path += numbers[i - 1].Path;
                }
            }

            return numbers[Find(Target, numbers)].Path;
        }

        public static int Find(int Num, Number [] numbers) 
        {
            int i = 0;
            foreach (var item in numbers)
            {
                if (item.Num == Num )
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public static void GetProgramsCountRec(int Num, int Target, int CountSum, int CountMult, ref int CountPath) 
        {
            if (Num < Target)
            {
                int temp, tempCountSum, tempCountMult;
                temp = Num + 1;
                tempCountSum = CountSum + 1;
                GetProgramsCountRec(temp, Target, tempCountSum, CountMult, ref CountPath);
                temp = Num * 2;
                tempCountMult = CountMult + 1;
                GetProgramsCountRec(temp, Target, CountSum, tempCountMult, ref CountPath);
            }
            else if (Num == Target)
            {
                CountPath++;
              //  Console.WriteLine("CountSum: " + CountSum + ",  CountMult: " + CountMult);
            }
            else
            {
                return;
            }
        }
    }
}
