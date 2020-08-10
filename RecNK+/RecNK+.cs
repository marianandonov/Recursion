using System;

namespace RecNK_
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp = 0;
            int n = TryParse("Enter N: ", temp);
            int k = TryParse("Enter K: ", temp);
            int[] arr = new int[k];
            GetComb(arr, 0, 1, n);
        }

        static void GetComb(int[] arr, int index, int start, int end)
        {
            if (index >= arr.Length)
            {
                Console.Write("(");
                for (int i = 0; i < arr.Length; i++)
                    if (i < arr.Length - 1) Console.Write("{0} ", arr[i]);
                    else Console.Write(arr[i]);
                Console.Write("), ");
            }
            else
                for (int i = start; i <= end; i++)
                {
                    arr[index] = i;
                    GetComb(arr, index + 1, i, end);
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
