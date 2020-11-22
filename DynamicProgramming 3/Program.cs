using System;

namespace DynamicProgramming_3
{
    class Program
    {

		//3. ***Требуется обойти конем шахматную доску размером NxM, пройдя через все поля доски по одному разу.Здесь алгоритм решения такой же, как в задаче о 8 ферзях.Разница только в проверке положения коня.
		//КрюковВН

        static void Main(string[] args)
        {
            Chess.MovePlotva();
            Console.ReadLine();
        }

		public static class Chess 
		{
			private static int[,] board;
			private static int[,] stepKnight;
			private static int W = 8;
			private static int H = 8;

			public static void MovePlotva()
			{
				Console.WriteLine("Задача 3 - Обойти конём шахматную доску\n");

				board = new int[W, H];
				stepKnight = new int[,] { { 2, 1 }, { 1, 2 }, { -1, 2 }, { -2, 1 }, { -2, -1 }, { -1, -2 }, { 1, -2 }, { 2, -1 } };
				ZeroBoard(board, W, H);

				Console.WriteLine($"Шахматная доска размером {W}x{H}. \n\n");
				PrintBoard(board, W, H);
				Console.WriteLine(" ------------------------------\n\n");

				SearchSolution(0, 0, 1);

				PrintBoard(board, W, H);

			}

			private static int SearchSolution(int x, int y, int n)
			{

				if (n == W * H)
				{
					board[x, y] = n;
					return 1;
				}

				int xNext;
				int yNext;
				int i;
				int count = stepKnight.GetUpperBound(0) + 1;

				for (i = 0; i < count; i++)
				{

					xNext = x + stepKnight[i, 0];
					yNext = y + stepKnight[i, 1];

					if (Convert.ToBoolean(checkCell(xNext, yNext)))
					{
						board[x, y] = n;

						if (Convert.ToBoolean(SearchSolution(xNext, yNext, n + 1)))
						{
							return 1;
						}

						board[x, y] = 0;
					}
				}
				return 0;
			}

			private static int checkCell(int x, int y)
			{
				if (x >= 0 && x < W && y >= 0 && y < H)
				{
					if (board[x, y] == 0)
					{
						return 1;
					}
				}
				return 0;
			}


			private static void ZeroBoard(int[,] b, int w, int h)
			{
				int i, j;

				for (i = 0; i < w; i++)
				{
					for (j = 0; j < h; j++)
					{
						b[i, j] = 0;
					}
				}
			}

			private static void PrintBoard(int[,] b, int w, int h)
			{
				int i, j;

				for (i = 0; i < w; i++)
				{
					for (j = 0; j < h; j++)
					{
						Console.Write($" {b[i, j]} ");
					}
					Console.WriteLine();
					Console.WriteLine();
				}
			}
		}	
	}
}
