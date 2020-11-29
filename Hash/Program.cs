using System;

namespace Hash
{
    class Program
    {
        //1. Реализовать простейшую хеш-функцию.На вход функции подается строка, на выходе сумма кодов символов.
        //    КрюковВН
        static void Main(string[] args)
        {
            Console.WriteLine($"Хеш для \"Проверка\": {GetHash("Проверка")}");
            Console.Write("Введите фразу для получения ее хеша: ");
            Console.WriteLine($"Результат хеш-функции: {GetHash(Console.ReadLine())}");
            Console.ReadLine();
        }

        public static uint GetHash(string s) 
        {
            uint hash = 0;

            if (!string.IsNullOrWhiteSpace(s))
            {
                foreach (var item in s)
                {
                    hash += Convert.ToUInt32(item);
                    hash -= (hash << 13) | (hash >> 19);
                }
            }

            return hash;
        }
    }
}
