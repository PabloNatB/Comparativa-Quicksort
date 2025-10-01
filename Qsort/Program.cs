using Qsort;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== EXPERIMENTOS DE ALGORITMOS DE ORDENAMIENTO ===\n");

        // Experimento 1: Quicksort vs Quicksort optimizado
        Experimento1_QuickSorts();

        // Experimento 2: Quicksort optimizado vs demás algoritmos
        Experimento2_TodosAlgoritmos();

        Console.WriteLine("\n\n_______Listo_______\n\n");
    }

    static void Experimento1_QuickSorts()
    {
        Console.WriteLine("Experimento 1: Quicksort vs Quicksort optimizado\n\n");

        var resultadosAleatorios = new List<string> { "n,QS_v1_Comparaciones,QS_v1_Intercambios,QS_v2_Comparaciones,QS_v2_Intercambios" };
        var resultadosOrdenados = new List<string> { "n,QS_v1_Comparaciones,QS_v1_Intercambios,QS_v2_Comparaciones,QS_v2_Intercambios" };

        
        Console.WriteLine("Experimento 1A");
        for (int i = 20; i < 1001; i+= 10)
        {
            
            int[] arrayAleatorio = ArrayGenerator.rand_n_array(i);

            // QuickSort v1
            var qs1 = new QuickSort_v1(arrayAleatorio);
            qs1.Q_Sortv1();

            // QuickSort v2
            var qs2 = new QuickSort_v2(arrayAleatorio);
            qs2.Q_Sortv2();

            resultadosAleatorios.Add($"{i},{qs1.NumComparisons},{qs1.NumSwaps},{qs2.NumComparisons},{qs2.NumSwaps}");

           
        }

        // Probar con arreglos ordenados (10 a 1000 elementos)
        Console.WriteLine("Experimento 1B");
        for (int i = 0; i < 11; i++)
        {
            int n = (int)Math.Pow(2, i);

            int[] arrayOrdenado = ArrayGenerator.n_array(n);

            // QuickSort v1
            var qs1 = new QuickSort_v1(arrayOrdenado);
            try
            {
                qs1.Q_Sortv1();
            }
            catch (StackOverflowException)
            {
                Console.WriteLine($"StackOverflow en QS_v1 con n={n} (arreglo ordenado)");
                break; 
            }

            // QuickSort v2
            var qs2 = new QuickSort_v2(arrayOrdenado);
            qs2.Q_Sortv2();

            resultadosOrdenados.Add($"{n},{qs1.NumComparisons},{qs1.NumSwaps},{qs2.NumComparisons},{qs2.NumSwaps}");

            
        }

        // Guardar resultados
        File.WriteAllLines("experimento1A.csv", resultadosAleatorios);
        File.WriteAllLines("experimento1B.csv", resultadosOrdenados);

        Console.WriteLine("Experimento 1 listo.\n");
    }

    static void Experimento2_TodosAlgoritmos()
    {
        Console.WriteLine("Experimento 2: Quicksort optimizado vs otros algoritmos\n\n");

        var resultadosAleatorios = new List<string> { "n,QS_v2_Comparaciones,QS_v2_Intercambios,Bubble_Comparaciones,Bubble_Intercambios,FlagBubble_Comparaciones,FlagBubble_Intercambios,Insertion_Comparaciones,Insertion_Intercambios,Selection_Comparaciones,Selection_Intercambios" };

        
        Console.WriteLine("Experimento 2A: Arreglos aleatorios\n");

        for (int i = 0; i < 15; i++)
        {
            int n = (int)Math.Pow(2, i);
            int[] temp_array = ArrayGenerator.rand_n_array(n);

            var resultados = all_implementations(temp_array, n);
            if (resultados != null)
            {
                resultadosAleatorios.Add(resultados);
            }
        }

        // 
        Console.WriteLine("Experimento 2B: Arreglos ordenados\n");
        var resultadosOrdenados = new List<string> { "n,QS_v2_Comparaciones,QS_v2_Intercambios,Bubble_Comparaciones,Bubble_Intercambios,FlagBubble_Comparaciones,FlagBubble_Intercambios,Insertion_Comparaciones,Insertion_Intercambios,Selection_Comparaciones,Selection_Intercambios" };
        
        for(int i=0; i < 17; i++)
        {
            int n = (int)Math.Pow(2, i);
            int[] temp_array = ArrayGenerator.n_array(n);

            var res = all_implementations(temp_array, n);
            if (res != null)
            {
                resultadosOrdenados.Add(res);
            }
        }

        // Guardar resultados
        File.WriteAllLines("experimento2A.csv", resultadosAleatorios);
        File.WriteAllLines("experimento2B.csv", resultadosOrdenados);

        Console.WriteLine("Experimento 2 listo.");
    }

    static string all_implementations(int[] array, int n)
    {
        try
        {
            // QuickSort v2 
            var qs2 = new QuickSort_v2(array);
            qs2.Q_Sortv2();

            // BubbleSort
            var bubble = new BubbleSort(array);
            bubble.B_Sort();

            // FlagBubbleSort
            var flagBubble = new FlagBubbleSort(array);
            flagBubble.FB_Sort();

            // InsertionSort
            var insertion = new InsertionSort(array);
            insertion.I_Sort();

            // SelectionSort
            var selection = new SelectionSort(array);
            selection.S_Sort();

            return $"{n},{qs2.NumComparisons},{qs2.NumSwaps}," +
                   $"{bubble.NumComparisons},{bubble.NumSwaps}," +
                   $"{flagBubble.NumComparisons},{flagBubble.NumSwaps}," +
                   $"{insertion.NumComparisons},{insertion.NumSwaps}," +
                   $"{selection.NumComparisons},{selection.NumSwaps}";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error con n={n}: {ex.Message}");
            return null;
        }
    }
}