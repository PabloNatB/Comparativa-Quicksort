using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Qsort
{
    //IMPLEMENTACIÓN BUBBLESORT
    //________________________________
    public class BubbleSort
    {
        public int[] Array { get; private set; }
        public int NumComparisons { get; private set; }
        public int NumSwaps { get; private set; }
        private int n;

        public BubbleSort(int[] array)
        {
            Array = (int[])array.Clone();
            NumComparisons = 0;
            NumSwaps = 0;
            n = Array.Length;
        }

        public void B_Sort()
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    NumComparisons++;
                    if (Array[j + 1] < Array[j])
                    {
                        // Swap
                        int temp = Array[j + 1];
                        Array[j + 1] = Array[j];
                        Array[j] = temp;

                        NumSwaps++;
                    }
                }
            }
        }
    }


    //IMPLEMENTACIÓN FLAG BUBBLESORT
    //________________________________
    public class FlagBubbleSort
    {
        public int[] Array { get; private set; }
        public int NumComparisons { get; private set; }
        public int NumSwaps { get; private set; }
        private int n;

        public FlagBubbleSort(int[] array)
        {
            Array = (int[])array.Clone();
            NumComparisons = 0;
            NumSwaps = 0;
            n = Array.Length;
        }

        public void FB_Sort()
        {
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    NumComparisons++;
                    if (Array[j + 1] < Array[j])
                    {
                        int temp = Array[j + 1];
                        Array[j + 1] = Array[j];
                        Array[j] = temp;

                        NumSwaps++;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }
    }


    //IMPLEMENTACIÓN QUICKSORT V1
    //________________________________
    public class QuickSort_v1
    {
        public int[] Array { get; private set; }
        public int NumComparisons { get; private set; }
        public int NumSwaps { get; private set; }
        private int n;

        public QuickSort_v1(int[] array)
        {
            Array = (int[])array.Clone();
            NumComparisons = 0;
            NumSwaps = 0;
            n = Array.Length;
        }

        

        private int Partition(int low, int high)
        {
            int i = low - 1;
            int pivot = Array[high];
            int temp;
            for (int j = low; j < high; j++)
            {
                NumComparisons++;
                if (Array[j] <= pivot)
                {
                    i++;
                    // swap
                    temp = Array[j];
                    Array[j] = Array[i];
                    Array[i] = temp;
                    NumSwaps++;
                }
            }

            // final swap
            temp = Array[i + 1];
            Array[i + 1] = Array[high];
            Array[high] = temp;
            NumSwaps++;

            return i + 1;
        }

        private void q_sort(int low, int high)
        {
            if (low < high)
            {
                int q = Partition(low, high);
                q_sort(low, q - 1);
                q_sort(q + 1, high);
            }
        }

        public void Q_Sortv1()
        {
            NumComparisons = 0;
            NumSwaps = 0;
            q_sort(0, n - 1);
        }
    }

    //IMPLEMENTACIÓN QUICKSORT V2
    //________________________________
    public class QuickSort_v2
    {
        public int[] Array { get; private set; }
        public int NumComparisons { get; private set; }
        public int NumSwaps { get; private set; }
        private int n;

        public QuickSort_v2(int[] array)
        {
            Array = (int[])array.Clone();
            NumComparisons = 0;
            NumSwaps = 0;
            n = Array.Length;
        }

        private int Median_Of_3(int low, int high)
        {
            int middle = (low + high + 1) / 2;
            int x1 = Array[low];
            int x2 = Array[middle];
            int x3 = Array[high];

            if ((x2 <= x1 && x1 <= x3) || (x3 <= x1 && x1 <= x2))
                return low;
            else if ((x1 <= x2 && x2 <= x3) || (x3 <= x2 && x2 <= x1))
                return middle;
            else
                return high;
        }

        private int Partition(int low, int high)
        {
            int i = low - 1;
            int pivotIndex = Median_Of_3(low, high);
            NumComparisons++;
            // swap pivot con high
            NumSwaps++;
            int temp = Array[pivotIndex];
            Array[pivotIndex] = Array[high];
            Array[high] = temp;

            int pivot = Array[high];

            for (int j = low; j < high; j++)
            {
                NumComparisons++;
                if (Array[j] <= pivot)
                {
                    i++;
                    // swap
                    temp = Array[j];
                    Array[j] = Array[i];
                    Array[i] = temp;
                    NumSwaps++;
                }
            }

            // final swap
            temp = Array[i + 1];
            Array[i + 1] = Array[high];
            Array[high] = temp;
            NumSwaps++;

            return i + 1;
        }

        private void q_sort(int low, int high)
        {
            if (low < high)
            {
                int q = Partition(low, high);
                q_sort(low, q - 1);
                q_sort(q + 1, high);
            }
        }

        public void Q_Sortv2()
        {
            NumComparisons = 0;
            NumSwaps = 0;
            q_sort(0, n - 1);
        }
    }


    //IMPLEMENTACIÓN INSERTION SORT
    //________________________________
    public class InsertionSort
    {
        public int[] Array { get; private set; }
        public int NumComparisons { get; private set; }
        public int NumSwaps { get; private set; }
        private int n;

        public InsertionSort(int[] array)
        {
            Array = (int[])array.Clone();
            NumComparisons = 0;
            NumSwaps = 0;
            n = Array.Length;
        }

        public void I_Sort()
        {
            for (int i = 1; i < n; i++)
            {
                var key = Array[i];
                int j = i - 1;
                while ( j >= 0 && Array[j] > key)
                {
                    NumComparisons++;
                    Array[j + 1] = Array[j];
                    j--;  
                    NumSwaps++;    
                }
                Array[j + 1] = key;
            }
        }
    }

    //IMPLEMENTACIÓN SELECTION SORT
    //________________________________
    public class SelectionSort
    {
        public int[] Array { get; private set; }
        public int NumComparisons { get; private set; }
        public int NumSwaps { get; private set; }
        private int n;

        public SelectionSort(int[] array)
        {
            Array = (int[])array.Clone();
            NumComparisons = 0;
            NumSwaps = 0;
            n = Array.Length;
        }

        public void S_Sort()
        {
            for (int i = 0; i < n - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < n; j++)
                {
                    NumComparisons++;
                    if (Array[j] < Array[min])
                    {
                        min = j;
                    }
                }
                NumSwaps++;
                int temp = Array[i];
                Array[i] = Array[min];
                Array[min] = temp;
            }
        }

    }

    //GENERAR ARREGLOS 
    //____________________________
    public static class ArrayGenerator
    {
        public static int[] rand_n_array(int n)
        {
            int[] Array = new int[n];
            Random random = new Random(100);
            int Valor;
            for (int i = 0; i < n; i++)
            {
                Valor = random.Next(0, 2 * n);
                Array[i] = Valor;
            }
            return Array;


        }

        public static int[] n_array(int n)
        {
            int[] Array = new int[n];
            for(int i = 0; i < n; i++)
            {
                Array[i] = i;
            }
            return Array;
        }
    }
    

}
