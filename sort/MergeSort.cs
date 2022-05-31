using System;

namespace Algorithms
{

    internal class Program
    {
        static void Main(string[] args)
        {


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
                for (int i = 0; right.Length > i; i++)
                {
                    right[i] = array[i + left.Length];
                }

                if (left.Length < 1)
                {
                    left = Sort(left);
                }
                if (right.Length < 1)
                {
                    right = Sort(right);
                }
                array = MergeSort(left, right);
            }
            return array;
        }

        public static int[] MergeSort(int[] left, int[] right)
        {

        }
    }
   