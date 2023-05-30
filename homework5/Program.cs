using static System.Console;
using static System.Math;

namespace Functions
{
    static class Homework5
    {
        public static (int, int, int) GetPropertiesOfIntArrayFromUser()
        {
            string? line;   // Ссылка на строку пользовательского ввода.
            int len = 0;    // Инициализация длины массива (которая является неизменяемой).
            int rndLimitMin = 0, rndLimitMax = 0;   // Инициализация пределов для генерации псевдослучайных
                                                    // чисел.

            while (true)
            {
                try
                {
                    Write("\nType number of items in integers array and press ENTER: ");
                    line = ReadLine();
                    len = line == null ? 0 : int.Parse(line);
                    if (len < 1)
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

            while (true)
            {
                try
                {
                    Write("\nType minimum value for random integer figures generator and press ENTER: ");
                    line = ReadLine();
                    rndLimitMin = line == null ? 0 : int.Parse(line);
                    break;
                }
                catch (OverflowException)
                {
                    WriteLine("Value is out of range!");
                    WriteLine("It must be in [0, 2_147_483_647]. Try again.");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Value must be an integer! Try again.");
                    continue;
                }
            }

            while (true)
            {
                try
                {
                    Write("\nType maximum value for random integer figures generator and press ENTER: ");
                    line = ReadLine();
                    rndLimitMax = line == null ? 0 : int.Parse(line);
    
                    if ((rndLimitMax-rndLimitMin)<2)
                    {
                        Write("\nMaximum value must be greater than minimum value by 2! Try again.");
                        continue;
                    }
                    break;
                }
                catch (OverflowException)
                {
                    WriteLine("Value is out of range!");
                    WriteLine("It must be in [2, 2_147_483_647]. Try again.");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Value must be an integer! Try again.");
                    continue;
                }
            }

            // Кортеж со свойствами массива:
            (int Len, int MinLimit, int MaxLimit) properties = (len, rndLimitMin, rndLimitMax);

            WriteLine($"\nLength of array: {properties.Len}");
            WriteLine($"Limits for integer values in array: [{properties.MinLimit} , {properties.MaxLimit})");
            return properties;
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
            print = $"[{string.Join(", ", array)}]"; 
            WriteLine($"\nYour 3-digit integer values array: {print}");
            return array;
        }

        public static int[] GetRndIntValuesArray(int len, int minLimit, int maxLimit)
        {
            var array = new int[len];   // Инициализация массива.
            var rnd = new Random();     // Новый объект генератора псевдослучайных чисел.
            string print = "";          // Ссылка на строковое представление массива.

            for (int i = 0; i < len; i++)
            {
                array[i] = rnd.Next(minLimit, maxLimit);
            }
            print = $"[{string.Join(", ", array)}]"; 
            WriteLine($"\nYour random integer values array: {print}");
            return array;
        }

        public static (int, int, int) GetPropertiesOfDoublesArrayFromUser()
        {
            string? line;   // Ссылка на строку пользовательского ввода.
            int len = 0;    // Инициализация длины массива (которая является неизменяемой).
            int range = 0, shift = 0;   // Инициализация пределов для генерации вещественных псевдослучайных
                                        // чисел. 
            int rndLimitMax;    // Верхний предел диапазона псевдослучайных чисел.

            while (true)
            {
                try
                {
                    Write("\nType number of items in doubles array and press ENTER: ");
                    line = ReadLine();
                    len = line == null ? 0 : int.Parse(line);
                    if (len < 1)
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

            while (true)
            {
                try
                {
                    Write("\nType range of values in doubles array and press ENTER: ");
                    line = ReadLine();
                    range = line == null ? 0 : int.Parse(line);
                    if (range < 1)
                    {
                        WriteLine("Range must be equal or greater than 1! Try again.");
                        continue;
                    }
                    break;
                }
                catch (OverflowException)
                {
                    WriteLine("Range must be in [1, 2_147_483_647]. Try again.");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Range must be an integer! Try again.");
                    continue;
                }
            }

            while (true)
            {
                try
                {
                    Write("\nType shift value for adjusting limits of range and press ENTER: ");
                    line = ReadLine();
                    shift = line == null ? 0 : int.Parse(line);
                    break;
                }
                catch (OverflowException)
                {
                    WriteLine("Shift must be in [-2_147_483_648, 2_147_483_647]. Try again.");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Shift must be an integer! Try again.");
                    continue;
                }
            }
            rndLimitMax = range + shift; 

            // Кортеж со свойствами массива:
            (int Len, int MinLimit, int Range) properties = (len, shift, range);

            WriteLine($"\nLength of array: {properties.Len}");
            WriteLine($"Limits of doubles in array: [{properties.MinLimit:N3}, {rndLimitMax:N3}]");
            return properties;
        }

        public static double[] GetRndDoublesArray(int len, int minLimit, int range)
        {
            var array = new double[len];   // Инициализация массива.
            var rnd = new Random();     // Новый объект генератора псевдослучайных чисел.
            string print = "";          // Ссылка на строковое представление массива.

            for (int i = 0; i < len; i++)
            {
                array[i] = Round((rnd.NextDouble() * range + minLimit), 3);
            }
            print = $"[{string.Join(", ", array)}]"; 
            WriteLine($"\nYour random double values array: {print}");
            return array;
        }

        // ЗАДАЧА 34.

        public static void EvensCount(int[] arr)
        {
            int count = 0;  // Инициализация счетчика четных чисел массива.

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    count += 1;
                }
            }
            WriteLine($"\nNumber of even values in array: {count}");
        }

        // ЗАДАЧА 36.

        public static void GetOddIndexValuesSum(int[] arr)
        {
            int sum = 0;    // Инициализация накопителя суммы.

            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 != 0)
                {
                    sum += arr[i];
                }
            }
            WriteLine($"\nSum of odd index values in array: {sum}");
        }

        // ЗАДАЧА 38.

        public static void GetDiffMaxAndMinValuesInDoublesArray(double[] arr)
        {
            double max = arr[0], min = 0, diff = 0;
            double maxValue = 0;    // Для хранения наибольшего значения массива.
            double[] filteredArr;   // Временный массив для сортировки.
            
            // Поиск наибольшего значения:
            for (int i = 0; i < arr.Length; i++)
            {  
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            maxValue = max;

            // Поиск наименьшего значения (но оптимальней было бы через преобразование в изменяемый список):
            while (arr.Length > 1)
            {
                filteredArr = Array.FindAll(arr, v => v != max);
                arr = filteredArr;
                max = arr[0];
                for (int i = 0; i < arr.Length; i++)
                {  
                    if (arr[i] > max)
                    {
                        max = arr[i];
                    }
                }
            }
            min = arr[0];

            diff = maxValue - min;
            WriteLine($"\nMax value: {maxValue}. Min value: {min}");
            WriteLine($"\nDifference between max and min values in array: {diff:N3}");
        }

        public static void Main()
        {
            (int Len, int MinLimit, int MaxLimit) arrayProperties = GetPropertiesOfIntArrayFromUser();
            WriteLine("\n----------");
            (int Len, int MinLimit, int Range) doublesArrayProperties = GetPropertiesOfDoublesArrayFromUser();

            WriteLine("\n----------");
            WriteLine("\nProcessing 'Задача 34':");
            int[] array = GetRnd3DigValuesArray(arrayProperties.Len);
            EvensCount(array);
            
            WriteLine("\n----------");
            WriteLine("\nProcessing 'Задача 36':");
            int[] array_1 = GetRndIntValuesArray(arrayProperties.Len, arrayProperties.MinLimit,
                                                 arrayProperties.MaxLimit);
            GetOddIndexValuesSum(array_1);

            WriteLine("\n----------");
            WriteLine("\nProcessing 'Задача 38':");
            double[] array_2 = GetRndDoublesArray(doublesArrayProperties.Len, doublesArrayProperties.MinLimit,
                                               doublesArrayProperties.Range);
            GetDiffMaxAndMinValuesInDoublesArray(array_2);    
        }
    }
}