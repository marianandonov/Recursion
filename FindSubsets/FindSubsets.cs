using System;

namespace FindSubsets
{
    class FindSubset
    {

        static string[] wordsArr;

        static void FindSubsets(int[] arr, int index, int start, int end)
        {
            if (index >= arr.Length)
            {
                Console.Write("(");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write("{0}", wordsArr[arr[i]]);
                    if (i != arr.Length - 1) Console.Write(" ");
                }
                Console.Write("), ");
            }
            else
                for (int i = start; i < end; i++)
                {
                    arr[index] = i;
                    FindSubsets(arr, index + 1, i + 1, end);
                }
        }

        static void Main(string[] args)
        {
            int n = 0;
            int length = TryParse("Enter arr length: ", n);
            wordsArr = new string[length];
            Console.WriteLine();
            for (int i = 0; i < wordsArr.Length; i++)
            {
                Console.Write("Enter [{0}] word: ", i);
                wordsArr[i] = Console.ReadLine();
            }
            int k = TryParse("Enter K: ", n);
            int[] arr = new int[k];
            Console.WriteLine();
            FindSubsets(arr, 0, 0, length);
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
