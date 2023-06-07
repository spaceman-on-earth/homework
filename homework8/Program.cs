using static System.Console;
using static System.Array;

namespace Recursion
{
    static class Homework8
    {
        // Для формирования 2-мерных массивов применим функции, которые работают на основе циклов.
        // Т.к. это второстепенная задача. В решениях задач ДЗ используются рекурсивные функции. 

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
            WriteLine(" ]");
        }

        // Для задачи 54.
        
        // Для решения задачи сортировки применим метод Хоара (алгоритм быстрой сортировки) для одномерного
        // массива. 
        // В массиве выбирается разрешающий (опорный) элемент - поворотная точка. Данный элемент предполагается
        // переместить в ту позицию, в которой он должен быть после упорядочивания всех элементов.
        // В процессе отыскания подходящей позиции для разрешающего элемента производятся перестановки
        // элементов так, что слева от нее будут находиться элементы, большие разрешающего, а справа — меньшие. 
        // Массив сортируется по убыванию.
        // Таким образом, массив разбивается на два подмассива относительно опорного элемента слева и справа.
        // Чтобы отсортировать два этих подмассива применяется рекурсивный вызов функции. 
        
        public static void SortValuesDesc(int[] array, int left, int right)
        {   
            int leftSave = left, rightSave = right; // Позиции "указатели" крайних элементов массива -
                                                    // границы сортировки.
            int pivot = array[left];                // Разрешающим элементом назначим первое значение в массиве.

            while (left < right)
            {
                while ((array[right] <= pivot) && (left < right))
                {   
                    right -= 1; // перемещаем правый указатель влево, пока его значение < опорного 
                }
                if (left != right)  // если границы не сомкнулись, перемещаем значение правого указателя на
                                    // место опорного и сдвигаем левую границу вправо
                {
                    array[left] = array[right];
                    left += 1;
                }
                
                while ((array[left] >= pivot) && (left < right))
                {   
                    left += 1;  // перемещаем левый указатель вправо, пока его значение > опорного
                }
                if (left != right)  // если границы не сомкнулись, перемещаем значение левого указателя на место
                                    // правого и сдвигаем левую границу влево
                {
                    array[right] = array[left];
                    right -= 1;
                }
            }

            array[right] = pivot;   // устанавливаем опорный элемент в точку поворота, когда правый указатель
                                    // оказывается слева от левого, - позиция для опорного элемента
            pivot = left;
            left = leftSave;    // восстанавливаем начальные индексы границ сортировки 
            right = rightSave;

            if (left < pivot)   // рекурсивно вызываем сортировку для левого и правого подмассивов
            {
                SortValuesDesc(array, left, pivot - 1);
            }
            if (right > pivot)
            {
                SortValuesDesc(array, pivot + 1, right);
            }
        }    

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
                SortValuesDesc(row, 0, array.GetLength(1) - 1); // вызов рекурсивной функции
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = row[j];
                }
            }
            return array;
        }

        // Для задачи 56.

        // Рекурсивная функция суммирования значений в одномерном массиве (строке 2-мерного массива).
        public static int SumIntValuesInRow(int[] array, int start, int end)
        {
            if (start > end || end > (array.Length - 1)) 
            {
                return 0;
            }
            else
            {
                return array[start] + SumIntValuesInRow(array, start + 1, end);
            }
        }

        public static int[] GetIntSumsInRows(int[,] array, int start, int end)
        {
            var sums = new int[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                sums[i] = SumIntValuesInRow(GetRow(array, i), start, end); // применение рекурсивного вызова
            }
            return sums;
        }
        
        // Для задачи 58.

        // Вспомогательная функция для вычисления каждого элемента матрицы, которая является
        // произведения двух исходных матриц.
        // i - строки первой матрицы, j - столбцы первой матрицы и строки второй, k - столбцы второй матрицы.
        // В итоге - 3 измерения. В j-измерении применим рекурсивный метод.
        public static int GetProductValue(int[,] arrayA, int[,] arrayB, int i, int j, int k)
        {   
            if (j < arrayA.GetLength(1))
            {
                return (arrayA[i, j] * arrayB[j, k] + GetProductValue(arrayA, arrayB, i, j + 1, k));
            }
            else return 0;
        }

        // Функция перемножения двух матриц (общий случай, когда матрицы могут быть разного размера).
        // В реализации совместно применены итерационный способ и рекурсивный.
        public static int[,] MultiplyInt2DArrays(int[,] arrayA, int[,] arrayB)
        {
            var productArray = new int[arrayA.GetLength(0), arrayB.GetLength(1)];

            for (int i = 0; i < arrayA.GetLength(0); i++)
                for (int k = 0; k < arrayB.GetLength(1); k++)
                {
                    int j = 0;
                    // рекурсивный вызов вспомогательной функции 
                    productArray[i, k] = GetProductValue(arrayA, arrayB, i, j, k);
                }
            return productArray;
        }    

        // Для задачи 60.

        public static void Main()
        {
            int m = 4, n = 4;   // Размер массива для задач 54 и 56.
            WriteLine("----------");
            WriteLine("\nCreating 2-dimensional array:");
            (int MinLimit, int MaxLimit) = SetRndIntLimits();
            var userArray = Get2DRndIntArray(m, n, MinLimit, MaxLimit);
            Print2DIntArray("Initial array", userArray);

            WriteLine("\n----------");
            WriteLine("\nProcessing 'Задача 54':");
            SortValuesInRowsDesc(userArray);
            Print2DIntArray("Array with sorted rows", userArray);

            WriteLine("\n----------");
            WriteLine("\nProcessing 'Задача 56':");
            var sums = GetIntSumsInRows(userArray, 0, n - 1);
            var printSums = $"[{String.Join(", ", sums)}]";
            WriteLine($"\nSum of values in each row: {printSums}");
            var sortedSums = new int[sums.Length];
            Copy(sums, sortedSums, sums.Length);
            SortValuesDesc(sortedSums, 0, n - 1);
            var indexOfMinSum = IndexOf(sums, sortedSums[n-1]); 
            WriteLine($"\nIndex of row with the least sum: {indexOfMinSum}");
            
            m = 2; n = 2;   // Размер массива для задач 58.
            WriteLine("\n----------");
            WriteLine("\nProcessing 'Задача 58':");
            WriteLine("\n> Form the first matrix:");
            (int MinLimit1, int MaxLimit1) = SetRndIntLimits();
            var matrix1 = Get2DRndIntArray(m, n, MinLimit1, MaxLimit1);
            WriteLine("\n> Form the second matrix:");
            (int MinLimit2, int MaxLimit2) = SetRndIntLimits();
            var matrix2 = Get2DRndIntArray(m, n, MinLimit2, MaxLimit2);
            Print2DIntArray("First matrix", matrix1);
            Print2DIntArray("Second matrix", matrix2);
            if (matrix1.GetLength(1) != matrix2.GetLength(0)) 
                WriteLine("Multiplication can not be processed!");
                // В данном случае учтено условие, при котором произведение матриц невозможно.
                // В реализации алгоритма размеры матриц одинаковые. 
            var productMatrix = MultiplyInt2DArrays(matrix1, matrix2);
            Print2DIntArray("Product matrix", productMatrix);
            WriteLine("");
        }
    }
}
