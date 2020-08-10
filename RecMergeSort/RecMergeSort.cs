using System;

namespace RecMergeSort
{
    class RecMergeSort
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

            MergeSortRec(arr, 0, length - 1);
            for (int i = 0; i < length; i++)
                Console.WriteLine(arr[i]);
        }

        static public void DoMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        static public void MergeSortRec(int[] numbers, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSortRec(numbers, left, mid);
                MergeSortRec(numbers, (mid + 1), right);
                DoMerge(numbers, left, (mid + 1), right);
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
