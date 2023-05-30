using static System.Console;

namespace TwoDimensionalArrays
{
    static class Homework7
    {
        public static void Get2DimensionsUserArray(int m, int n)
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
        }

        public static void Main()
        {
            int m = 3, n = 4;   // Размер массива для задачи 47.
            
            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 47':");
            Get2DimensionsUserArray(m, n);

        }
    }
}
