using System;
using System.Collections;

namespace RadixSort
{
/*    Сравнение производится поразрядно: сначала сравниваются значения одного крайнего разряда, и элементы группируются 
        по результатам этого сравнения, затем сравниваются значения следующего разряда, соседнего, 
        и элементы либо упорядочиваются по результатам сравнения значений этого разряда внутри образованных на предыдущем проходе групп, 
        либо переупорядочиваются в целом, но сохраняя относительный порядок, достигнутый при предыдущей сортировке.
        Затем аналогично делается для следующего разряда, и так до конца.
Так как выравнивать сравниваемые записи относительно друг друга можно в разную сторону, на практике существуют два варианта этой сортировки.
            Для чисел они называются в терминах значимости разрядов числа, и получается так: можно выровнять записи чисел в сторону 
            менее значащих цифр (по правой стороне, в сторону единиц, least significant digit, LSD) или более значащих цифр
        (по левой стороне, со стороны более значащих разрядов, most significant digit, MSD).
При LSD сортировке(сортировке с выравниванием по младшему разряду, направо, к единицам) получается порядок, 
        уместный для чисел.Например: 1, 2, 9, 10, 21, 100, 200, 201, 202, 210. То есть, здесь значения 
            сначала сортируются по единицам, затем сортируются по десяткам, сохраняя отсортированность 
            по единицам внутри десятков, затем по сотням, сохраняя отсортированность по десяткам и единицам внутри сотен, и т. п.
При MSD сортировке (с выравниванием в сторону старшего разряда, налево), получается алфавитный 
        порядок, который уместен для сортировки строк текста.Например «b, c, d, e, f, g, h, i, j, ba» 
            отсортируется как «b, ba, c, d, e, f, g, h, i, j». Если MSD применить к числам, приведённым 
            в примере получим последовательность 1, 10, 100, 2, 200, 201, 202, 21, 210, 9.*/
    class Program
    {
        //msd:
        public static void sorting(int[] arr, int range, int length)
        {
            ArrayList[] lists = new ArrayList[range];
            for (int i = 0; i < range; ++i)
                lists[i] = new ArrayList();

            for (int step = 0; step < length; ++step)
            {
                //распределение по спискам
                for (int i = 0; i < arr.Length; ++i)
                {
                    int temp = (arr[i] % (int)Math.Pow(range, step + 1)) /
                                                  (int)Math.Pow(range, step);
                    lists[temp].Add(arr[i]);
                }
                //сборка
                int k = 0;
                for (int i = 0; i < range; ++i)
                {
                    for (int j = 0; j < lists[i].Count; ++j)
                    {
                        arr[k++] = (int)lists[i][j];
                    }
                }
                for (int i = 0; i < range; ++i)
                    lists[i].Clear();
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[10];

            Random rd = new Random();
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = rd.Next(0, 100);
            }

            System.Console.WriteLine("The array before sorting:");
            foreach (double x in arr)
            {
                System.Console.Write(x + " ");
            }

            sorting(arr, 10, 2);
            System.Console.WriteLine("\n\nThe array after sorting:");

            foreach (double x in arr)
            {
                System.Console.Write(x + " ");
            }

            System.Console.WriteLine("\n\nPress the <Enter> key");
            System.Console.ReadLine();
        }
    }
}
