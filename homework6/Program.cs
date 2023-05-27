using static System.Console;

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

        
        public static void Main()
        {
            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 41':");
            int[] userArray = GetUserArray();
            CountPositiveNumbersInArray(userArray);
        }
              
    }
}
