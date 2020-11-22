using System;

namespace DynamicProgramming_2
{
    //2. Решить задачу о нахождении длины максимальной последовательности с помощью матрицы.
    //    КрюковВН
    class Program
    {
        static void Main(string[] args)
        {
			GetLengthSeq();
			Console.ReadLine();
        }

		public static void GetLengthSeq()
		{
			Console.WriteLine("Задача 2 - Наибольшая общая подпоследовательность с помощью матрицы.");
			Console.WriteLine("Данные взяты из методички к уроку\n");

			int Alen = 10;
			int Blen = 9;

			char[] A = { 'G', 'E', 'E', 'K', 'B', 'R', 'A', 'I', 'N', 'S' };
			char[] B = { 'G', 'E', 'E', 'K', 'M', 'I', 'N', 'D', 'S' };

			int[,] C = new int[10, 11]; //C[Blen + 1][Alen + 1]

			int i;
			int j;

			for (i = 0; i <= Alen; i++)
			{
				C[0, i] = 0;
			}

			for (i = 1; i <= Blen; i++)
			{
				C[i, 0] = 0;
			}

			for (i = 1; i <= Blen; i++)
			{
				for (j = 1; j <= Alen; j++)
				{
					if (B[i - 1] == A[j - 1])
					{
						C[i, j] = C[i - 1, j - 1] + 1;
					}
					else
					{
						C[i, j] = C[i, j - 1] > C[i - 1, j] ? C[i, j - 1] : C[i - 1, j];
					}
				}
			}

			Console.Write("A[]");

			for (i = 0; i < Alen; i++)
			{
				Console.Write($" {A[i]}");
			}

			Console.WriteLine();
			Console.WriteLine();

			for (i = 0; i <= Blen; i++)
			{
				if (i > 0)
				{
					Console.Write($"{B[i - 1]}  ");
				}
				else
				{
					Console.Write("B[]");
				}

				for (j = 0; j <= Alen; j++)
				{
					Console.Write($" {C[i, j]}");
				}

				Console.WriteLine();
			}
		}
    }
}
