using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec_to_Bin
{
    //Реализовать функцию перевода чисел из десятичной системы в двоичную, используя
    //рекурсию.
    //Крюков ВН
    class Program
    {
        static void Main(string[] args)
        {            
            int Dec;
            do
            {
                Console.WriteLine("Введите число: ");
            } 
            while (!int.TryParse(Console.ReadLine(), out Dec));
            Console.WriteLine(DecToBin(Dec));
            Console.ReadLine();
        }

        public static string DecToBin(int Dec) 
        {
            return Dec == 0 ? String.Empty : DecToBin(Dec / 2) + ((Dec % 2 == 0) ? "0" : "1");
        }
    }
}
