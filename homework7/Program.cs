using static System.Console;

namespace TwoDimensionalArrays
{
    static class Homework7
    {
        public static double[,] Get2DUserDoublesArray(int m, int n)
        {
            var userArray = new double[m,n];
            var row = new double[n];    // Строка пользовательского массива.
            string? s;              // Символьная строка для хранения пользовательского ввода.
            string printRow;        // Строка вывода.

            WriteLine("\nCreating 2-dimensional array. Type your number and press ENTER.");
            for (int i = 0; i < m; i++)
            {
                WriteLine($"\n> Row {i}:\n");
                
                for (int j = 0; j < n;)
                {
                    try
                    {
                        Write($">> Item {j}: ");
                        s = ReadLine();
                        userArray[i, j] = s == null ? 0 : double.Parse(s);
                        j += 1;
                    }
                    catch (OverflowException)
                    {
                        WriteLine("The number is out of range!");
                        WriteLine("It must be in [-2_147_483_648, 2_147_483_647]. Try again.");
                    }
                    catch (FormatException)
                    {
                        WriteLine("Number must be of Double type! Try again.");
                    }
                }
            }
            WriteLine("Input finished.");

            WriteLine("\nYour array:");
            WriteLine("> [ ");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    row[j] = Math.Round(userArray[i, j], 3);
                }
                printRow = String.Join(", ", row);
                WriteLine($"    {printRow}");
            }
            WriteLine("  ]\n");

            return userArray;
        }

        public static (int, int) SetRndDoublesLimits()
        {
            int range, shift;   // Инициализация пределов для генерации вещественных псевдослучайных чисел.
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

            (int MinLimit, int Range) properties = (shift, range);
            return properties;
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

        public static void Print2DArray(int m, int n, double[,] array)
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

        public static (int, int) GetPositionInUserArray()
        {
            string? str_i, str_j;   // Строки для пользовательского ввода.
            int i, j;               // Индекс строки и столбца соответственно.

            WriteLine("\nType row index 'i' and column index 'j' and press ENTER.");
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
                    WriteLine("Incorrect input! Try again.");
                    continue;
                }
            }

            (int I, int J) position = (i, j);
            return position;
        }

        public static void Main()
        {
            int m = 3, n = 4;   // Размер массива для задач 47 и 48.
            
            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 47':");
            (int MinLimit, int Range) rndDoublesLimits = SetRndDoublesLimits();
            var array = Get2DRndDoublesArray(m, n, rndDoublesLimits.MinLimit, rndDoublesLimits.Range);
            Print2DArray(m, n, array);


            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 48':");
            (int I, int J) position = GetPositionInUserArray();
            if (position.I > (m - 1) || position.J > (n - 1))
            {
                WriteLine("\nNo such item in array!\n");
            }
            else
            {
                WriteLine($"\nValue in position: {array[position.I, position.J]}\n");
            }

        }
    }
}
