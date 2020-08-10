using System;

namespace Labyrinth
{
    class Labyrinth
    {

        static char[,] lab =
            {
                {' ', ' ', ' ', '*', ' ', ' ', ' '},
                {'*', '*', ' ', '*', ' ', '*', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', '*', '*', '*', '*', '*', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'е'},
            };
        static void Main()
        {
            FindPath(0, 0);
        }

        static void FindPath(int row, int col)
        {

            if ((col < 0) || (row < 0) ||
                  (col >= lab.GetLength(1)) || (row >= lab.GetLength(0));
            {
                return;
            }
            if (lab[row, col] == 'е')
            {
                Console.WriteLine("Found the exit!");
            }
            if (lab[row, col] != ' ')
            {
                return;
            }
            lab[row, col] = 's';
            FindPath(row, col - 1);
            FindPath(row - 1, col);
            FindPath(row, col + 1);
            FindPath(row + 1, col);
            lab[row, col] = ' ';
        }
    }
}
