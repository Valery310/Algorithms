using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pow
{

    //2. Реализовать функцию возведения числа a в степень b:
    //a.Без рекурсии.
    //b.Рекурсивно.
    //c. *Рекурсивно, используя свойство чётности степени
    //Крюков ВН

    class Program
    {
        static void Main(string[] args)
        {
            int Number, _Pow;
            do
            {
                Console.WriteLine("Введите число: ");
            }
            while (!int.TryParse(Console.ReadLine(), out Number));

            do
            {
                Console.WriteLine("Введите степень: ");
            }
            while (!int.TryParse(Console.ReadLine(), out _Pow));

            Console.WriteLine(Pow(Number, _Pow));
            int Result = 1;
            Result = PowRec(Number, _Pow, Result);
            Console.WriteLine("Результат рекурсивного метода: "+ Result);
            Console.ReadLine();
        }

        public static int Pow(int Number, int Pow) 
        {
            int Result = 1;

            if (Pow == 0)
            {
                return 1;
            }

            for (int i = 0; i < Pow; i++)
            {
                Result = Result * Number;
            }

            return Result;
        }

        public static int PowRec(int Number, int Pow, int Result)
        {
            if (Pow > 1)
            {
                Pow--;
                Result = Result * Number;
                return PowRec(Number, Pow, Result);
            }
            else if (Pow == 0)
            {
                return 1;
            }
            else
            {
                return Result = Result * Number;
            }
        }
    }
}
