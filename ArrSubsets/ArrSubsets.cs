using System;

namespace ArrSubsets
{
    class ArrSubsets
    {
        static void Main(string[] args)
        {
            int n = 0;
            int length = TryParse("Enter arr length: ", n);
            int[] arr = new int[length];

            for (int i = 0; i < length; i++)
            {
                arr[i] = TryParse($"Enter [{i}] element: ", n);
            }

            int sum = TryParse("Enter sum: ", n);

            if (SubsetSum(arr, arr.Length, sum) == true) Console.WriteLine("Found a subset with given sum");
            else Console.WriteLine("No subset with given sum");
            Console.ReadLine();
        }

        public static bool SubsetSum(int[] arr, int n, int sum)
        {
            bool[,] subset = new bool[sum + 1, n + 1];

            for (int i = 0; i <= n; i++)
                subset[0, i] = true;

            for (int i = 1; i <= sum; i++)
                subset[i, 0] = false;

            for (int i = 1; i <= sum; i++)
                for (int j = 1; j <= n; j++)
                {
                    subset[i, j] = subset[i, j - 1];
                    if (i >= arr[j - 1])
                        subset[i, j] = subset[i, j] || subset[i - arr[j - 1], j - 1];
                }

            return subset[sum, n];
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
