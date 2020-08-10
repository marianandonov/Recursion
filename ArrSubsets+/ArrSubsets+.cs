using System;

namespace ArrSubsets_
{
    class Program
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

            for (int i = 0; i < arr.Length; i++)
            {
                int first = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int second = arr[j];

                    if ((first + second) == sum) Console.WriteLine("({0}, {1}) ", first, second);
                    else Console.WriteLine("No subsets with given sum");
                }
            }
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
