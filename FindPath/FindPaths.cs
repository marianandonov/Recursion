using System;

namespace FindPath
{
    class FindPaths
    {
        static void Main(string[] args)
        {
            int temp = 0;
            int m = TryParse("Enter M: ", temp);
            int n = TryParse("Enter N: ", temp);
            Console.WriteLine("Possible paths: {0}", NumberOfPaths(m, n));
        }

        static int NumberOfPaths(int m, int n)
        {
            int[,] count = new int[m, n];

            for (int i = 0; i < m; i++)
                count[i, 0] = 1;

            for (int j = 0; j < n; j++)
                count[0, j] = 1;

            for (int i = 1; i < m; i++)
                for (int j = 1; j < n; j++)
                    count[i, j] = count[i - 1, j] + count[i, j - 1];

            return count[m - 1, n - 1];
        }

        static int TryParse(string message, int num)
        {
            bool tryParse = false;

            do
            {
                Console.Write(message);
                tryParse = int.TryParse(Console.ReadLine(), out num);
                if (tryParse == true) return num;
                else Console.WriteLine("Try Again!");
            } while (tryParse == false);

            return num;
        }

    }
}
