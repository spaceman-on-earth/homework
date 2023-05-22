using static System.Console;
using static System.Math;

namespace Functions
{
    static class Homework4
    {
        // ЗАДАЧА 25.

        public static void GetPowFromUserInput()
        {
            int A, B, pow;
            string? lineA, lineB;

            while (true)
            {
                try
                {
                    Write("\nType integer 'A' and press ENTER: ");
                    lineA = ReadLine();
                    A = lineA == null ? 0 : int.Parse(lineA);
                    if (A == 0)
                    {
                        WriteLine("'A' must be nonzero! Try again.");
                        continue;
                    }
                    break;
                }
                catch (OverflowException)
                {
                    WriteLine("Your number is out of range.");
                    WriteLine("It must be in [-2_147_483_648, 2_147_483_647]. Try again.\n");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("'A' must be an integer! Try again.");
                    continue;
                }    
            }        
            WriteLine("Input OK.\n");

            while (true)
            {    
                try
                {    
                    Write("Type integer 'B' and press ENTER: ");
                    lineB = ReadLine();
                    B = lineB == null ? 0 : int.Parse(lineB);
                    if (B < 0)
                    {
                        WriteLine("'B' must be nonnegative! Try again.\n");
                        continue;
                    }
                    break;    
                }
                catch (OverflowException)
                {
                    WriteLine("Your number is out of range.");
                    WriteLine("It must be in [-2_147_483_648, 2_147_483_647]. Try again.\n");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("'B' must be an integer! Try again.");
                    continue;
                }
            }
            WriteLine("Input OK.\n");        
                    
            if (B == 0)
            {
                WriteLine($"{A}^{B} = 1");
            }
            else
            {
                pow = A;
                for (int i = 1; i < B; i++)
                {
                    pow = checked(pow * A);
                }
                WriteLine($"{A}^{B} = {pow}"); 
            }
                   
        }

        // ЗАДАЧА 27.

        public static int GetUserInput()
        {
            int userNumber;
            string? userLine;
            
            while(true)
            {
                Write("\nType an integer number and press ENTER: ");
                try
                {
                    userLine = ReadLine();
                    userNumber = userLine == null ? 0 : int.Parse(userLine);
                    break;
                }
                catch (OverflowException)
                {
                    WriteLine("Your number is out of range!");
                    WriteLine("It must be in [-2_147_483_648, 2_147_483_647]. Try again.");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Number must be an integer! Try again.");
                    continue;
                }
            }
            WriteLine("Input OK.\n");
            return userNumber;
        }
        
        public static void GetSumOfDigits()
        {
            int userNumber = GetUserInput(), acc = 0, digitsSum = 0;

            if (userNumber < 10 && userNumber > -10)
            {
                digitsSum = Abs(userNumber);
                WriteLine($"Sum of all digits in number: {digitsSum}");
            }
            else
            {
                while (userNumber / 10 != 0)
                {
                    acc += (userNumber % 10);
                    userNumber /= 10;
                }
                digitsSum = checked(acc + userNumber);
                WriteLine($"Sum of all digits in number: {Abs(digitsSum)}");
            }
        }

        // ЗАДАЧА 29.

        public static void GetUserArray()
        {
            int len = 0;
            string? line;

            while (true)
            {
                try
                {
                    Write("\nType the number of items in array and press ENTER: ");
                    line = ReadLine();
                    len = line == null ? 0 : int.Parse(line);
                    if (len <= 0)
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

            var array = new int[len];

            WriteLine("\nEnter array items one by one:\n");
            for (int i = 0; i < len; i++)
            {        
                while (true)    
                {    
                    try
                    {
                        Write($"array[{i}] = ");
                        line = ReadLine();
                        array[i] = line == null ? 0 : int.Parse(line);
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
            }         
            Write("\nYour array is: [ ");
            for (int i = 0; i < len; i++)
            {
                Write($"{array[i]} ");
            }
            Write("]");
        }

        static void Main()
        {
            // Вызвать желаемую функцию из определенных в классе с указанием вх. параметров 
            // (вводом с клавиатуры или передачей аргументов соответственно):

            GetUserArray();
        }
    }
}