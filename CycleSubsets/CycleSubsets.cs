using System;

namespace CycleSubsets
{
    class CycleSubsets
    {

        static string[] strings, str;
        static int length;

        static void Cycle(int iter, int index, int k)
        {
            if (iter == k)
            {
                for (int i = 0; i < length; i++)
                    Console.WriteLine("({0})", str[i]);
                return;
            }

            for (int i = index; i < strings.Length; i++)
            {
                str[iter] = strings[i];
                Cycle(iter + 1, i + 1, k);
            }
        }

        static void Main(string[] args)
        {
            int n = 0;
            length = TryParse("Enter words length: ", n);

            strings = new string[length];

            for (int i = 0; i < length; i++)
            {
                Console.Write("Enter [{0}] word: ", i);
                strings[i] = Console.ReadLine();
            }

            for (int i = 0; i <= length; i++)
            {
                str = new string[length];
                Cycle(0, 0, i);
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
