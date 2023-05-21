using static System.Console;

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
                    pow *= A;
                }
                WriteLine($"{A}^{B} = {pow}"); 
            }
                   
        }

        static void Main()
        {
            // Вызвать желаемую функцию из определенных в классе с указанием вх. параметров 
            // (вводом с клавиатуры или передачей аргументов соответственно):

            GetPowFromUserInput();
        }
    }
}