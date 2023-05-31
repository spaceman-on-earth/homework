using static System.Console;

namespace TwoDimensionalArrays
{
    static class Homework7
    {
        // Для Задачи 47.

        public static (int, int) SetRndDoublesLimits()
        {
            int range, shift;   // Пределы для генерации вещественных псевдослучайных чисел.
            string? s;          // Строка для пользовательского ввода.
            
            while (true)
            {
                try
                {
                    Write("\nType range of values in doubles array and press ENTER: ");
                    s = ReadLine();
                    range = s == null ? 0 : int.Parse(s);
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
                    s = ReadLine();
                    shift = s == null ? 0 : int.Parse(s);
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
            WriteLine($"\nLimits of doubles in array: [{shift:N3}, {(range + shift):N3}]");

            (int MinLimit, int Range) rndLimits = (shift, range);
            return rndLimits;
        }
            
        public static double[,] Get2DRndDoublesArray(int m, int n, int minLimit, int range)
        {
            var userArray = new double[m,n];
            var rnd = new Random();     // Новый объект генератора псевдослучайных чисел.

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    userArray[i, j] = Math.Round((rnd.NextDouble() * range + minLimit), 3);    
                }
            }
            return userArray;
        }

        public static void Print2DDoublesArray(int m, int n, double[,] array)
        {
            var row = new double[n];    // Строка пользовательского массива.
            string printRow;            // Строка вывода.
            
            WriteLine("\nYour array:");
            WriteLine(" [ ");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    row[j] = array[i, j];
                }
                printRow = String.Join(", ", row);
                WriteLine($"   {printRow}");
            }
            WriteLine(" ]\n");
        }

        // Для Задачи 48.    

        public static (int, int) GetPositionInUserArray()
        {
            string? str_i, str_j;   // Строки для пользовательского ввода.
            int i, j;               // Индекс строки и столбца соответственно.

            WriteLine("\nEnter row index 'i' and column index 'j'.");
            while (true)
            {
                try
                {
                    Write("\ni : ");
                    str_i = ReadLine();
                    i = str_i == null ? 0 : int.Parse(str_i);
                    Write("j : ");
                    str_j = ReadLine();
                    j = str_j == null ? 0 : int.Parse(str_j);
                    if (i < 0 || j < 0)
                    {
                        WriteLine("Incorrect index! Try again.");
                        continue;
                    }
                    break;
                }
                catch (OverflowException)
                {
                    WriteLine("Index is out of range!");
                    WriteLine("It must be in [0, 2_147_483_647]. Try again.");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Incorrect value! Try again.");
                    continue;
                }
            }

            (int I, int J) position = (i, j);
            return position;
        }

        // Для Задачи 52.

        public static (int, int) SetRndIntLimits()
        {
            int rndLimitMin, rndLimitMax;   // Пределы для генерации псевдослучайных целых чисел.
            string? s;                      // Строка для пользовательского ввода.

            while (true)
            {
                try
                {
                    Write("\nType minimum value for random integers generator and press ENTER: ");
                    s = ReadLine();
                    rndLimitMin = s == null ? 0 : int.Parse(s);
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
                    s = ReadLine();
                    rndLimitMax = s == null ? 0 : int.Parse(s);
    
                    if ((rndLimitMax-rndLimitMin)<2)
                    {
                        Write("Maximum value must be greater than minimum value by 2! Try again.\n");
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
            WriteLine($"\nLimits for integer values in array: [{rndLimitMin} , {(rndLimitMax - 1)}]");

            (int MinLimit, int MaxLimit) rndLimits = (rndLimitMin, rndLimitMax);
            return rndLimits;
        }

        public static int[,] Get2DRndIntArray(int m, int n, int minLimit, int maxLimit)
        {
            var userArray = new int[m,n];
            var rnd = new Random();     // Новый объект генератора псевдослучайных чисел.

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    userArray[i, j] = rnd.Next(minLimit, maxLimit);    
                }
            }
            return userArray;
        }

        public static void Print2DIntArray(int m, int n, int[,] array)
        {
            var row = new int[n];    // Строка пользовательского массива.
            string printRow;         // Строка вывода.
            
            WriteLine("\nYour array:");
            WriteLine(" [ ");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    row[j] = array[i, j];
                }
                printRow = String.Join(", ", row);
                WriteLine($"   {printRow}");
            }
            WriteLine(" ]");
        }

        public static void GetAverageInColumns(int m, int n, int[,] array)
        {
            int acc;        // Накопитель суммы элементов в столбце.
            double sum;     // Сумма в вещественном представлении.
            double average; // Среднее арифметическое значений в столбце.
            var averageValues = new double[n];  // Массив для хранения средних арифметических значений.
            
            for (int j = 0; j < n; j++)
            {
                acc = 0;
                for (int i = 0; i < m; i++)
                {
                    acc += array[i, j];
                }
                sum = acc;
                average = Math.Round((sum / m), 3);
                averageValues[j] = average;
            }
            WriteLine($"\nAverage values in columns: [{String.Join(", ", averageValues)}]\n");
        }

        public static void Main()
        {
            int m = 3, n = 4;   // Размер массива для задач.
            
            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 47':");
            (int MinLimit, int Range) rndDoublesLimits = SetRndDoublesLimits();
            var doublesArray = Get2DRndDoublesArray(m, n, rndDoublesLimits.MinLimit, rndDoublesLimits.Range);
            Print2DDoublesArray(m, n, doublesArray);

            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 48':");
            (int I, int J) position = GetPositionInUserArray();
            if (position.I > (m - 1) || position.J > (n - 1))
            {
                WriteLine("\nNo such item in array!\n");
            }
            else
            {
                WriteLine($"\nValue in position: {doublesArray[position.I, position.J]}\n");
            }

            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 52':");
            (int MinLimit, int MaxLimit) rndIntLimits = SetRndIntLimits();
            var intArray = Get2DRndIntArray(m, n, rndIntLimits.MinLimit, rndIntLimits.MaxLimit);
            Print2DIntArray(m, n, intArray);
            GetAverageInColumns(m, n, intArray);
        }
    }
}
