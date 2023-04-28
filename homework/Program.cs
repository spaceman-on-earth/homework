using static System.Console;

namespace Functions
{
    static class MyFunctions
    {
        static class Homework1
        {
            // ЗАДАЧА 2. Функция сравнения двух (целых) чисел:
            public static void CompareTwoInt()
            {
                int a, b, max;
                string? s;  // Переменная для пользовательского ввода

                while(true)
                {
                    /* Обработка исключения при возможной ошибке преобразования типов
                    в случае, когда вводятся недопустимые значения,
                    без прерывания хода выполнения программы:*/
                    try
                    {
                        Write("Type your first number and press ENTER: ");
                        s = ReadLine();

                        a = s == null ? 0 : int.Parse(s);
                        WriteLine("Successful input \n");

                        Write("Type your second number and press ENTER: ");
                        s = ReadLine();

                        b = s == null ? 0 : int.Parse(s);
                        WriteLine("Successful input \n");

                        if (a > b)
                        {
                            max = a;
                        }
                        else
                        {
                            max = b;
                        }

                        WriteLine($"max = {max}");
                        break;
                    }
                    catch (FormatException)
                    {
                        WriteLine("The number must be an integer! Try again \n");
                        continue;
                    }  
                }
            }

            // ЗАДАЧА 4. Функция определения наибольшего из последовательности целых чисел:
            public static void GetMaxInt(int length)
            {
                var intArray = new int[length];    // Создаем массив для хранения чисел
                int max;        // Переменная для наибольшего значения
                bool isInt;     // Переменная для проверки ввода значений
            
                for(int i = 0; i < length;)
                {
                    Write($"Type value#{i} and press ENTER: ");
                    isInt = int.TryParse(ReadLine(), out intArray[i]);
		
		            // Проверка допустимости введенных значений:
                    if (isInt)
                    {
                        WriteLine("Successful input \n");
                        i += 1;
                    }
                    else
                    {
                        WriteLine("The value must be an integer! Try again \n");
                        continue;
                    }  
                }
            
                max = intArray[0];
                foreach (int value in intArray)
                {
                    if (value > max)
                    {
                        max = value;
                    } 
                }
            
                WriteLine($"Max value: {max}");
            }

            // ЗАДАЧА 6. Функция проверки на четность:
            public static void IsEven(int number)
            {               
                if (number % 2 == 0)
                {
                    WriteLine("True \n");
                }
                else
                {
                    WriteLine("False \n");
                }
            }

            // ЗАДАЧА 8. Функция, выводящая все четные числа на отрезке:
            public static void GetEvens(int N)
            {                     
                var intArray = new int[N];  // Создаем массив для хранения чисел 
                intArray[0] = 1;            // Задаем начальное значение отрезка

                for (int i = 1; i < N; i++)
                {
                    intArray[i] = i + 1;
                }
                Write("Numerical sequence: ");
                foreach (var i in intArray)
                {
                    Write($"{i} ");
                }

                Write("\nEven numbers: ");
                foreach (var i in intArray)
                {
                    if (i % 2 == 0)
                    {
                        Write($"{i} ");
                    }
                }
            }
        }

        static class Homework2
        {
            // ЗАДАЧА 10. Функция, принимающая трехзначное число и выводящая вторую цифру этого числа:
            public static void GetSecondInThreeDigit()
            {
                int number;
                bool isInt;
                string s; 

                while(true)
                {
                    Write("\nType three-digit integer number and press ENTER: ");
                    isInt = int.TryParse(ReadLine(), out number);

                    if (isInt)
                    {
                        s = number.ToString();
                        if (s.Length == 3)
                        {
                            WriteLine("\nSecond digit in number is " + s[1]);
                            break;
                        }
                        else
                        {
                            WriteLine("The number must be a three-digit integer!");
                            continue;
                        }
                    }
                    WriteLine("The number must be a three-digit integer!");
                }
            }

            // ЗАДАЧА 13. Функция, выводящая третью цифру заданного числа или сообщение, что третьей цифры нет:
            public static void GetThirdDigit()
            {
                int number;
                bool isInt;
                string s;

                while(true)
                {
                    Write("\nType any integer number and press ENTER: ");
                    isInt = int.TryParse(ReadLine(), out number);

                    if (isInt)
                    {
                        s = number.ToString();
                        if (s.Length >= 3)
                        {
                            WriteLine("\nThird digit in number is " + s[2]);
                            break;
                        }
                        else
                        {
                            WriteLine("\nThere is no third digit in your number");
                            break;
                        }
                    }
                    WriteLine("The number must be an integer!");
                }
            }

            // ЗАДАЧА 15:
            public static bool IsWeekend(int nDay)
            {
                int[] weekDays = {1, 2, 3, 4, 5, 6, 7};
                bool weekend = true;

                if (nDay > 0 && nDay < 8)
                {
                    int i = Array.IndexOf(weekDays, nDay);
                    if (i >= 5)
                    {
                        WriteLine("True \n");
                        return weekend;
                    }
                    WriteLine("False \n");
                    return !weekend;
                }
                else
                {
                    WriteLine("Incorrect week day number");
                    return !weekend;
                }
            }
        }

        // Точка входа в программу
        static void Main()
        {
            // Вызвать желаемый метод из определенных в классе с указанием вх. параметров 
            // (вводом с клавиатуры или передачей аргументов соответственно):
            
            Homework2.IsWeekend(7);
        }
    }
}
