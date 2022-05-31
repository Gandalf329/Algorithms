using System;

namespace Algorithms
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[6] { 7, 3, 8, 2, 1, 4 };
            array = Sort(array);

            foreach(int num in array)
            {
                Console.WriteLine(num);
            }
        }
        public static int[] Sort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }
            else
            {
                int[] left = new int[array.Length / 2];
                int[] right = new int[array.Length - left.Length];

                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = array[i];
                }
                for (int i = 0;i < right.Length ; i++)
                {
                    right[i] = array[i + left.Length];
                }

                if (left.Length > 1)
                {
                    left = Sort(left);
                }
                if (right.Length > 1)
                {
                    right = Sort(right);
                }
                array = MergeSort(left, right);

            }

            return array;
        }

        static int[] MergeSort(int[] left, int[] right)
        {
            int[] array = new int[left.Length + right.Length];
              
            int l = 0;  
            int r = 0;  

            for (int i = 0; i < array.Length; i++)
            {

                if (r >= right.Length)
                {
                    array[i] = left[l];
                    l++;
                }
                else if (l < left.Length && left[l] < right[r])
                {
                    array[i] = left[l];
                    l++;
                }
                else
                {
                    array[i] = right[r];
                    r++;
                   
                }
            }
            return array;
        }
    }
}
