using static System.Console;

namespace Functions
{
    static class Homework5
    {
        // ЗАДАЧА 34.

        public static int GetLengthOfArrayFromUser()
        {
            string? line;   // Ссылка на строку пользовательского ввода.
            int len = 0;    // Инициализация длины массива (которая является неизменяемой).

            while (true)
            {
                try
                {
                    Write("\nType the number of items in array and press ENTER: ");
                    line = ReadLine();
                    len = line == null ? 0 : int.Parse(line);
                    if (len <= 0)
                    {
                        WriteLine("The number must be nonzero and nonnegative! Try again.");
                        continue;
                    }
                    break;
                }
                catch (OverflowException)
                {
                    WriteLine("The number is out of range!");
                    WriteLine("It must be in [1, 2_147_483_647]. Try again.");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Number must be an integer! Try again.");
                    continue;
                }
            }
            return len;
        }

        public static int[] GetRnd3DigValuesArray(int len)
        {
            var array = new int[len];   // Инициализация массива.
            var rnd = new Random();     // Новый объект генератора псевдослучайных чисел.
            string print = "";          // Ссылка на строковое представление массива.

            for (int i = 0; i < len; i++)
            {
                array[i] = rnd.Next(100, 1000);
            }
            //Write("]");
            print = $"[{string.Join(", ", array)}]"; 
            WriteLine($"\nYour 3-digit values array: {print}");
            return array;
        }

        public static void EvensCount(int[] arr)
        {
            int len = arr.Length;
            int count = 0;  // Инициализация счетчика четных чисел массива.

            for (int i = 0; i < len; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    count += 1;
                }
            }
            WriteLine($"\nNumber of even values in array: {count}");
        }
        
        public static void Main()
        {
            int length = GetLengthOfArrayFromUser();
            int[] array = GetRnd3DigValuesArray(length);
            EvensCount(array);

        }
    }
}