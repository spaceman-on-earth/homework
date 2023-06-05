using static System.Console;
using static System.Array;

namespace Recursion
{
    static class Homework8
    {
        // Для формирования 2-мерных массивов применим функции, которые работают на основе циклов.
        // Т.к. это второстепенная задача. Решения задач ДЗ реализованы на основе рекурсии. 

        public static (int, int) SetRndIntLimits()
        {
            int rndLimitMin, rndLimitMax;   // Пределы для генерации псевдослучайных целых чисел.
            string? s;                      // Строка для пользовательского ввода.

            while (true)
            {
                try
                {
                    Write("\nType minimum value for random integers generator and press ENTER: ");
                    s = ReadLine();
                    rndLimitMin = s == null ? 0 : int.Parse(s);
                    break;
                }
                catch (OverflowException)
                {
                    WriteLine("Value is out of range!");
                    WriteLine("It must be in [-2_147_483_648, 2_147_483_645]. Try again.");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Value must be an integer! Try again.");
                    continue;
                }
            }
            while (true)
            {
                try
                {
                    Write("\nType maximum value for random integers generator and press ENTER: ");
                    s = ReadLine();
                    rndLimitMax = s == null ? 0 : int.Parse(s);

                    checked
                    {
                        if ((rndLimitMax-rndLimitMin)<2)
                        {
                            Write("Maximum value must be greater than minimum value by 2! Try again.\n");
                            continue;
                        }
                    }
                    break;
                }
                catch (OverflowException)
                {
                    WriteLine("Value is out of range!");
                    WriteLine("It must be in [-2_147_483_646, 2_147_483_647]. Try again.");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Value must be an integer! Try again.");
                    continue;
                }
            }
            WriteLine($"\nLimits for integer values in array: [{rndLimitMin} , {(rndLimitMax - 1)}]");

            (int MinLimit, int MaxLimit) rndLimits = (rndLimitMin, rndLimitMax);
            return rndLimits;
        }

        public static int[,] Get2DRndIntArray(int m, int n, int minLimit, int maxLimit)
        {
            var userArray = new int[m,n];
            var rnd = new Random();     // Новый объект генератора псевдослучайных чисел.

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    userArray[i, j] = rnd.Next(minLimit, maxLimit);    
                }
            }
            return userArray;
        }

        public static void Print2DIntArray(string definition, int[,] array)
        {
            var row = new int[array.GetLength(1)];  // Строка пользовательского массива.
            string printRow;    // Строка вывода.
            
            WriteLine($"\n{definition}:");
            WriteLine(" [ ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    row[j] = array[i, j];
                }
                printRow = String.Join(", ", row);
                WriteLine($"   {printRow}");
            }
            WriteLine(" ]\n");
        }

        // Для задачи 54.
        
        public static void SortValuesInRowDesc(int[] array, int left, int right)
        {   
            int leftSave = left, rightSave = right;
            int pivot = array[left];

            while (left < right)
            {
                while ((array[right] <= pivot) && (left < right))
                {   
                    right -= 1; 
                }
                if (left != right)
                {
                    array[left] = array[right];
                    left += 1;
                }
                
                while ((array[left] >= pivot) && (left < right))
                {   
                    left += 1;  
                }
                if (left != right)
                {
                    array[right] = array[left];
                    right -= 1;
                }
            }

            array[right] = pivot;
            pivot = left;
            left = leftSave;
            right = rightSave;

            if (left < pivot)
            {
                SortValuesInRowDesc(array, left, pivot - 1);
            }
            if (right > pivot)
            {
                SortValuesInRowDesc(array, pivot + 1, right);
            }
        }    
            
            //public static void SortValuesInRowsDesc(int m, int n, int[,] array);
            //int temp;   // Переменная для временного хранения значений.
            
            //if (m > 0)
            //{
                //if (n > 1)
                //{
                    //if (array[(m-1), (n-2)] > array[(m-1), (n-1)])
                    //{
                        //SortValuesInRowsDesc(m, (n - 1), array);
                    //}
                    //else
                    //{
                        //temp = array[(m-1), (n-2)];
                        //array[(m-1), (n-2)] = array[(m-1), (n-1)];
                        //array[(m-1), (n-1)] = temp;
                        //SortValuesInRowsDesc(m, (n - 1), array);
                    //}
                    
                //}
                //SortValuesInRowsDesc((m - 1), n, array);
            //}

        public static int[] GetRow(int[,] array, int i)
        {
            var row = new int[array.GetLength(1)];

            for (int j = 0; j < array.GetLength(1); j++)
            {
                row[j] = array[i, j];
            }
            return row;
        }

        public static int[,] SortValuesInRowsDesc(int[,] array)
        {
            int[] row = new int[array.GetLength(1)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                row = GetRow(array, i);
                SortValuesInRowDesc(row, 0, array.GetLength(1) - 1);
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = row[j];
                }
            }
            return array;
        }

        public static int GetSumOfValuesInRow(int[] array, int start, int end)
        {
            if (start > end) 
            {
                return 0;
            }
            else
            {
                return array[start] + GetSumOfValuesInRow(array, start + 1, end);
            }
        }  

        public static void Main()
        {
            int m = 4, n = 4;   // Размер массива для задач 54 и 56.
            
            (int MinLimit, int MaxLimit) = SetRndIntLimits();
            var userArray = Get2DRndIntArray(m, n, MinLimit, MaxLimit);
            Print2DIntArray("Initial array", userArray);

            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 54':");
            //SortValuesInRowsDesc(m, n, userArray);
            SortValuesInRowsDesc(userArray);
            Print2DIntArray("Array with sorted rows", userArray);

            WriteLine("----------");
            WriteLine("\nProcessing 'Задача 56':");

            
            
        }
    }
}
