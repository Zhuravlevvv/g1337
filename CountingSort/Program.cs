using System;

namespace CountingSort
{
/*    Идея алгоритма заключается в следующем:

    считаем количество вхождений каждого элемента массива;
    исходя из данных полученных на первом шаге, формируем отсортированный массив.*/
    class Program
    {
        
        static int[] BasicCountingSort(int[] array, int k)
        {
            //поиск минимального и максимального значений
            var min = array[0];
            var max = array[0];
            foreach (int element in array)
            {
                if (element > max)
                {
                    max = element;
                }
                else if (element < min)
                {
                    min = element;
                }
            }

            //поправка
            var correctionFactor = min != 0 ? -min : 0;
            max += correctionFactor;

            var count = new int[max + 1];
            for (var i = 0; i < array.Length; i++)
            {
                count[array[i] + correctionFactor]++;
            }

            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    array[index] = i - correctionFactor;
                    index++;
                }
            }

            return array;
        }

        //метод для получения массива заполненного случайными числами
        static int[] GetRandomArray(int arraySize, int minValue, int maxValue)
        {
            var random = new Random();
            var randomArray = new int[arraySize];
            for (var i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(minValue, maxValue);
            }

            return randomArray;
        }

        static void Main(string[] args)
        {
            var arr = GetRandomArray(10, 0, 9);
            Console.WriteLine("Входные данные: {0}", string.Join(", ", arr));
            Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", BasicCountingSort(arr, 9)));
            Console.ReadLine();
        }
    }
}
