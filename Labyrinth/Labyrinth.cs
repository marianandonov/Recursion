using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

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
                {' ', ' ', ' ', ' ', ' ', ' ', 'е'}
            };



        static char[] path = new char[lab.GetLength(0) * lab.GetLength(1)];
        static int position = 0;
        static int counter = 0;
        static List<int> lengths = new List<int>();
        static List<string> list = new List<string>();

        static void FindPath(int row, int col, char direction)
        {

            if ((col < 0) || (row < 0) ||
                  (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)))
            {
                return;
            }

            path[position] = direction;
            position++;

            if (lab[row, col] == 'е')
            {
                list.Add(GetMaxPath(path, 1, position - 1));
                counter++;
            }

            if (lab[row, col] == ' ')
            {
                lab[row, col] = 's';
                FindPath(row, col - 1, 'L'); // left
                FindPath(row - 1, col, 'U'); // up
                FindPath(row, col + 1, 'R'); // right
                FindPath(row + 1, col, 'D'); // down
                lab[row, col] = ' ';
            }

            position--;

            lengths.Add(list[counter].Length);
        }

        static string GetMaxPath(char[] path, int startPos, int endPos)
        {
            string s = "";
            for (int pos = startPos; pos <= endPos; pos++)
            {
                s += path[pos];
            }
            return s;
        }

        static void Main()
        {
            FindPath(0, 0, 'S');
            int max = lengths.Max;
            Console.WriteLine($"The longest path is {max} moves long!");
        }
    }
}
