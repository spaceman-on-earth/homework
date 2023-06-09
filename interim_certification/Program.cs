using static System.Console;

namespace Recursion
{
    static class InterimCertification
    {
        // Для задачи 64.

        public static int[] GetAllNatNumbersDescSequence(int[] array, int N)
        {
            if (N >= 1)
            {
                array[array.Length-N] = N;
                GetAllNatNumbersDescSequence(array, N - 1);
            }
            return array;
        }

        public static int[] GetAllNatNumbersDesc()
        {
            int N;  // Количество натуральных чисел.
            int[] naturalNumbers;   // Массив для хранения натуральных чисел.
            string? input;   // Строка пользовательского ввода.

            while(true)
            {
                try
                {   
                    Write("\nType required amount of natural numbers and press ENTER: ");
                    input = ReadLine();
                    if (int.TryParse(input, out N))
                    {
                        if (N < 1)
                        {
                            WriteLine("Incorrect input! Try again.");
                            continue;
                        }
                        else break;
                    }
                    else
                    {
                        WriteLine("Incorrect input! Try again.");
                        continue;
                    }
                }
                catch (OverflowException)
                {
                    WriteLine("Amount is out of range!");
                    WriteLine("It must be in [1, 2_147_483_647]. Try again.");
                    continue;
                }    
            }
            naturalNumbers = new int[N];
            GetAllNatNumbersDescSequence(naturalNumbers, N);

            return naturalNumbers;
        }

        public static void Main()
        {
            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 64':");
            var naturalNumbers = GetAllNatNumbersDesc();
            var print = String.Join(", ", naturalNumbers);
            WriteLine($"\nNatural numbers: {print}\n");
        }
    }
}
