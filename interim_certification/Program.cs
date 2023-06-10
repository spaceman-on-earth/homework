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

        // Для задачи 66.

        public static int GetSumOfAscNatNumbers(int M, int N)
        {
            if (M <= N)
            {
                return (M + GetSumOfAscNatNumbers(M + 1, N));
            }
            else return 0;
        }

        public static int GetSumOfDescNatNumbers(int M, int N)
        {
            if (M >= N)
            {
                return (M + GetSumOfDescNatNumbers(M - 1, N));
            }
            else return 0;
        }

        public static int GetSumOfNatNumbersInRange()
        {
            int M, N;   // Границы промежутка натуральных чисел для суммирования.
            int sum;    // Сумма натуральных чисел.
            string? input;   // Строка пользовательского ввода.

            while(true)
            {
                try
                {   
                    Write("\nType starting natural number and press ENTER: ");
                    input = ReadLine();
                    if (int.TryParse(input, out M))
                    {
                        if (M < 1)
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
                    WriteLine("Number is out of range!");
                    WriteLine("It must be in [1, 2_147_483_647]. Try again.");
                    continue;
                }    
            }
            while(true)
            {
                try
                {   
                    Write("\nType ending natural number and press ENTER: ");
                    input = ReadLine();
                    if (int.TryParse(input, out N))
                    {
                        if (M < 1)
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
                    WriteLine("Number is out of range!");
                    WriteLine("It must be in [1, 2_147_483_647]. Try again.");
                    continue;
                }    
            }

            if (M < N)
            {
                return sum = GetSumOfAscNatNumbers(M, N);
            }
            else if (M > N)
            {
                return sum = GetSumOfDescNatNumbers(M, N);
            }
            else return M;
        }

        // Для задачи 68.

        public static int GetAckermannFunc(int m, int n)
        { 

            if (n > 0 && m == 0)
            {
                return n + 1;
            }
            else if (m > 0 && n == 0)
            {
                return GetAckermannFunc(m - 1, 1);
            }
            else if (m > 0 && n > 0)
            {
                return GetAckermannFunc(m - 1, GetAckermannFunc(m, n - 1));
            }
            else return 0;
        }

        public static void Main()
        {
            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 64':");
            var naturalNumbers = GetAllNatNumbersDesc();
            var print = String.Join(", ", naturalNumbers);
            WriteLine($"\nNatural numbers: {print}\n");

            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 64':");
            int sum = GetSumOfNatNumbersInRange();
            WriteLine($"\nSum of natural numbers on the interval: {sum}\n");

            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 68':");
            int m = 3, n = 2;
            int ackermann = GetAckermannFunc(m, n);
            WriteLine($"\nResult of the Ackermann function A({m}, {n}): {ackermann}\n");
        }
    }
}
