using static System.Console;
using static System.Array;

namespace Recursion
{
    static class Homework8
    {
        // Для формирования 2-мерных массивов применим функции, которые работают на основе циклов.
        // Т.к. это второстепенная задача. Решения задач ДЗ реализованы на основе рекурсии. 

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
                    WriteLine("It must be in [-2_147_483_648, 2_147_483_645]. Try again.");
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
                    Write("\nType maximum value for random integers generator and press ENTER: ");
                    s = ReadLine();
                    rndLimitMax = s == null ? 0 : int.Parse(s);

                    checked
                    {
                        if ((rndLimitMax-rndLimitMin)<2)
                        {
                            Write("Maximum value must be greater than minimum value by 2! Try again.\n");
                            continue;
                        }
                    }
                    break;
                }
                catch (OverflowException)
                {
                    WriteLine("Value is out of range!");
                    WriteLine("It must be in [-2_147_483_646, 2_147_483_647]. Try again.");
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

        public static void Print2DIntArray(string definition, int[,] array)
        {
            var row = new int[array.GetLength(1)];  // Строка пользовательского массива.
            string printRow;    // Строка вывода.
            
            WriteLine($"\n{definition}:");
            WriteLine(" [ ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    row[j] = array[i, j];
                }
                printRow = String.Join(", ", row);
                WriteLine($"   {printRow}");
            }
            WriteLine(" ]");
            WriteLine();
        }

        // Для задачи 54.

        

        public static void Main()
        {
            int m = 4, n = 4;   // Размер массива для задач 54 и 56.
            
            (int MinLimit, int MaxLimit) = SetRndIntLimits();
            Print2DIntArray("Initial array", Get2DRndIntArray(m, n, MinLimit, MaxLimit));

            
            
        }
    }
}
