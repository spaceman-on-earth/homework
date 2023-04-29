using static System.Console;
using static System.Math;

namespace Functions
{
    static class Homework3
    {
        // 
        public static int GetUserInput()
        {
            int userNumber;
            string? userLine;
            
            while(true)
            {
                Write("\nВведите натуральное число: ");
                try
                {
                    userLine = ReadLine();
                    userNumber = userLine == null ? 0 : int.Parse(userLine);    // Только для компилятора,
                    // чтобы не выдавал предупреждение о возможной нулевой ссылке.

                    if (userNumber < 0)
                    {
                        WriteLine("Число должно быть положительным. Повторите ввод.\n");
                        continue;
                    }
                    break;
                }
                catch (OverflowException)
                {
                    WriteLine("Введенное значение слишком большое.");
                    WriteLine("Число не должно быть больше 2_147_483_647. Повторите ввод.\n");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Введенное значение не является натуральным числом.");
                    WriteLine("Повторите ввод.\n");
                    continue;
                }
            }
            WriteLine("Successful input. \n");
            return userNumber;
        }

        public static void IsPalindrome()
        {
            int userNumber = GetUserInput();
            int quotient = userNumber;
            int bitLength = 0;    // Начальная разрядность числа
            int remainder = 0;
            int maxRank = 10;
            int reversedUserNumber = 0;

            if (userNumber < 10)
            {
                WriteLine("Введенное число является палиндромом.\n");
            }
            else if ((userNumber % 10) == 0)
            {
                WriteLine("Введенное число не является палиндромом.\n");
            }
            else
            {
                while(quotient / 10 != 0)
                {
                    bitLength += 1;
                    quotient /= 10;
                }
                WriteLine($"Введено {bitLength+1}-значное число");

                quotient = userNumber;

                for(int i = 1; i < bitLength; i++)
                {
                    maxRank *= 10;
                }
                WriteLine($"{maxRank:N0} - наибольший разряд\n");

                for(int i = 0; i <= bitLength; i++)
                {
                    remainder = quotient % 10;
                    reversedUserNumber += remainder*maxRank;

                    quotient /= 10;
                    maxRank /= 10;
                }
                WriteLine($"Введенное число в обратном порядке: {reversedUserNumber}");

                if (reversedUserNumber == userNumber)
                {
                    WriteLine("Введенное число является палиндромом.\n");
                }
                else
                {
                    WriteLine("Введенное число не является палиндромом.\n");
                }
            }     
        }

        static void Main()
        {
            IsPalindrome();
        }
    }
}
