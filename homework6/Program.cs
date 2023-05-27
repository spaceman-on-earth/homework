using static System.Console;
using static System.Math;

namespace Functions
{
    static class Homework6
    {
        public static int[] GetUserArray()
        {
            string? s;      // Строка для хранения пользовательского ввода
            int userNumber; // Очередное пользовательское число.
            int M = 1;      // Порядковый номер числа = количество чисел, введенных пользователем.
            var userArray = new int[M];   // Инициализация массива для хранения чисел пользователя.
            string printArray;  // Ссылка на строковое представление массива.

            WriteLine("\nType your number and press ENTER. Leave field empty and press ENTER for finish.");
            WriteLine("***");
            Write($"{M}: ");
            s = ReadLine();

            while (s != "")
            {
                try
                {   
                    userNumber = s == null ? 0 : int.Parse(s);
                    userArray[M-1] = userNumber;
                    M += 1;
                    Array.Resize(ref userArray, M); // Данное расположение выражения в паре с *
                                                    // учитывает все варианты позиций отбрасываемых
                                                    // недопустимых значений
                    Write($"\n{M}: ");
                    s = ReadLine(); 
                }
                catch (OverflowException)
                {
                    WriteLine("The number is out of range!");
                    WriteLine("It must be in [-2_147_483_648, 2_147_483_647]. Try again.");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Number must be an integer! Try again.");
                    Write($"\n{M}: ");
                    s = ReadLine();
                    continue;
                }      
            }
            Array.Resize(ref userArray, M-1);   // *
            WriteLine("Input finished.");

            printArray = $"[{string.Join(", ", userArray)}]"; 
            WriteLine($"\nYour array: {printArray}");
            return userArray;
        }

        public static void CountPositiveNumbersInArray(int[] array)
        {
            int count = 0;  // Инициализация счетчика положительных чисел.

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    count += 1;
                }
            }
            WriteLine($"Positive numbers: {count}\n");
        }

        public static (double, double) GetLineEquation()
        {
            string? s;  // Ссылка на строку пользовательского ввода.
            double k;  // Инициализация углового коэффициента прямой.
            double b;

            WriteLine("\n   (confirm input by pressing ENTER)\n");
            while (true)
            {
                try
                {
                    Write("k = ");
                    s = ReadLine();
                    k = s == null ? 0 : double.Parse(s);
                    break;
                }
                catch (FormatException)
                {
                    WriteLine("Number must be double! Try again.");
                    continue;
                }
            }
            WriteLine();

            while (true)
            {    
                try
                {
                    Write("b = ");
                    s = ReadLine();
                    b = s == null ? 0 : double.Parse(s);
                    break;
                }
                catch (FormatException)
                {
                    WriteLine("Number must be double! Try again.");
                    continue;
                }
            }

            (double K, double B) line = (k, b);
            return line;
        }

        public static void GetIntersection(double k1, double k2, double b1, double b2)
        {
            double x, y; // Координаты точки пересечения.

            if (k1 == k2)
            {
                if (b1 == b2)
                {
                    WriteLine("\nLines coincide.\n");
                }
                else
                {
                    WriteLine("\nLines are parallel.\n");
                }
            }
            else
            {
                y = Round((k1*b2 - b1*k2)/(k1 - k2), 3);
                if (k2 == 0.0)
                {
                    x = Round((y - b1)/k1, 3);
                }
                else
                {
                    x = Round((y - b2)/k2, 3);
                }
                WriteLine($"\nPoint of intersection: ({x}; {y})\n");
            }
        }

        public static void Main()
        {
            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 41':");
            int[] userArray = GetUserArray();
            CountPositiveNumbersInArray(userArray);

            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 43':");
            WriteLine("\n>> Equation for straight line 1");
            (double K1, double B1) line_1 = GetLineEquation();
            WriteLine("\n>> Equation for straight line 2");
            (double K2, double B2) line_2 = GetLineEquation();
            GetIntersection(line_1.K1, line_2.K2, line_1.B1, line_2.B2);
        }       
    }
}
