using static System.Console;
using static System.Math;

namespace Functions
{
    static class Homework3
    {
        // ЗАДАЧА 19.
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
            int quotient = userNumber;      // Переменная для хранения значений частного от деления на основание
            int bitLength = 0;      // Начальная разрядность числа
            int remainder = 0;      // Остаток от деления
            int maxRank = 10;       // Наибольший разряд числа
            int reversedUserNumber = 0;     // Число в обратном порядке следования цифр

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

        // ЗАДАЧА 21.
        public static void GetDistanceBetweenPoints()
        {
            double x1, x2, y1, y2, z1, z2;
            bool isDouble;
            double distance;

            WriteLine("Введите координаты первой точки:");
            while(true)
            {
                Write("\nx1 = ");
                isDouble = double.TryParse(ReadLine(), out x1);
                if (isDouble)
                {
                    WriteLine("Input OK.");
                    break;
                }
                WriteLine("Введено некорректное значение. Попробуйте снова.");
            }
            while(true)
            {
                Write("\ny1 = ");
                isDouble = double.TryParse(ReadLine(), out y1);
                if (isDouble)
                {
                    WriteLine("Input OK.");
                    break;
                }
                WriteLine("Введено некорректное значение. Попробуйте снова.");
            }
            while(true)
            {
                Write("\nz1 = ");
                isDouble = double.TryParse(ReadLine(), out z1);
                if (isDouble)
                {
                    WriteLine("Input OK.");
                    break;
                }
                WriteLine("Введено некорректное значение. Попробуйте снова.");
            }

            WriteLine("\nВведите координаты второй точки:");
            while(true)
            {
                Write("\nx2 = ");
                isDouble = double.TryParse(ReadLine(), out x2);
                if (isDouble)
                {
                    WriteLine("Input OK.");
                    break;
                }
                WriteLine("Введено некорректное значение. Попробуйте снова.");
            }
            while(true)
            {
                Write("\ny2 = ");
                isDouble = double.TryParse(ReadLine(), out y2);
                if (isDouble)
                {
                    WriteLine("Input OK.");
                    break;
                }
                WriteLine("Введено некорректное значение. Попробуйте снова.");
            }
            while(true)
            {
                Write("\nz2 = ");
                isDouble = double.TryParse(ReadLine(), out z2);
                if (isDouble)
                {
                    WriteLine("Input OK.");
                    break;
                }
                WriteLine("Введено некорректное значение. Попробуйте снова.");
            }

            var A = (x1, y1, z1);
            var B = (x2, y2, z2);
            WriteLine($"\nт. A: ({A.x1}, {A.y1}, {A.z1})");
            WriteLine($"т. B: ({B.x2}, {B.y2}, {B.z2})");
            
            double diffX = (x2 - x1)*(x2 - x1);
            double diffY = (y2 - y1)*(y2 - y1);
            double diffZ = (z2 - z1)*(z2 - z1);
            
            distance = Sqrt(diffX + diffY + diffZ);
            WriteLine($"Расстояние между точками: {distance:f2}\n");
        }

        // ЗАДАЧА 23.
        public static void GetPowerOfNumerics(int N, int degree)
        {
            var values = new int[N];    // Инициализация массива для хранения чисел последовательности
            values[0] = 1;      // Первое число последовательности
            int v;      // Отдельное число последовательности
            int exp = degree;       // Желаемая степень, в которую следует возвести числа 

            for (int i = 1; i < N; i++)
            {
                values[i] = i + 1;
            }
            WriteLine("\nПоследовательность чисел имеет вид: ");
            foreach (var n in values)
            {
                Write($"{n} ");
            }

            for (int i = 0; i < N; i++)
            {
                v = values[i];
                for (int j = 1; j < exp; j++)
                {
                    values[i] *= v;
                }
            }
            WriteLine($"\nПоследовательность чисел, возведенных в степень {exp}: ");
            foreach (var n in values)
            {
                Write($"{n} ");
            }
        }

        static void Main()
        {
            // Вызвать желаемую функцию из определенных в классе с указанием вх. параметров 
            // (вводом с клавиатуры или передачей аргументов соответственно):

            GetPowerOfNumerics(5, 3);
        }
    }
}
