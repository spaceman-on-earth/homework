using static System.Console;

namespace Functions
{
    class MyFunctions
    {
        // ЗАДАЧА 2. Функция сравнения двух (целых) чисел:
        static void CompareTwoInt()
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
        static void getMaxInt(int length)
        {
            var intArray = new int[length];    // Создаем массив для хранения чисел
            var max = 0;    // Переменная для наибольшего значения
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
        static void isEven(int number)
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
        static void getEvens(int N)
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

        // Точка входа в программу
        static void Main()
        {
            // Вызвать желаемый метод из определенных в классе с указанием вх. параметров 
            // (вводом с клавиатуры или передачей аргументов соответственно):
            

        }
    }
}
