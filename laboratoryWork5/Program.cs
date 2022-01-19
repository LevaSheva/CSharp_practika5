using System;

namespace laboratoryWork5
{
    class Program
    {
        static Random rnd = new Random();
        static int[] arr = null;
        static int[,] arr2 = null;
        static int[][] arr3 = null;

        static void Main()
        {
            while (ShowMenu()) { }
        }

        private static bool ShowMenu()
        {
            Console.WriteLine(@"
:::::::::: Главное меню ::::::::::
----------------------------------
1. Работа с одномерным массивом
2. Работа с двумерным массивом
3. Работа с рваным массивом
----------------------------------
0. Выход");
            switch (SelectAction("\nВыберите тип массива: "))
            {
                case 1:
                    Array_1D();
                    return true;
                case 2:
                    Array_2D();
                    return true;
                case 3:
                    raggedArray();
                    return true;
                case 0:
                    Environment.Exit(0);
                    return true;
                default:
                    Console.WriteLine("\nНекорректный ввод! Пожалуйста, повторите попытку!\n");
                    return true;
            }
        }

        private static void Array_1D()
        {
            while (ShowMenu1D()) { }
        }
                
        private static bool ShowMenu1D()
        {
            Console.WriteLine(@"
::: Одномерный массив :::
-------------------------
1. Создать массив
2. Напечатать массив
3. Добавить после каждого отрицательного элемента его модуль
-------------------------
0. Назад");
      
            switch (SelectAction("\nВведите номер действия: "))
            {
                case 1:
                    int size = Array1D_Size("\nВведите размер одномерного массива: ");
                    arr = Array1D_Fill(size);
                    return true;
                case 2:
                    Console.WriteLine("\nОдномерный массив:\n");
                    Array1D_Print();
                    return true;
                case 3:
                    Console.WriteLine("\nОбновлённый одномерный массив:\n ");
                    Array1D_Add();
                    return true;
                case 0:
                    return false;
                default:
                    return false;
            }
        }

        private static int[] Array1D_Fill(int size)
        {
            int[] arr = new int[size];

            Console.WriteLine("\nВыберите способ формирования одномерного массива:\n1. Вручную\n2. С помощью класса Random");

            switch(ReadInt_FillArray("\nВведите номер действия: ", 1, 2))
            {
                case 1:
                    for (int i = 0; i < size; i++)
                    {
                        arr[i] = ReadInt($"Введите значение элемента массива с индексом {i}:  ");
                    }
                    break;

                case 2:
                    Random rnd = new Random();

                    for (int i = 0; i < size; i++)
                    {
                        arr[i] = rnd.Next(-100, 100);
                    }
                    break;
            }
            return arr;
        }

        private static void Array1D_Print()
        {
            if (arr == null)
            {
                Console.WriteLine("\nОдномерный массив не инициализирован!\n");
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"| {arr[i]} ");
            }
            Console.WriteLine("|");
        }

        private static void Array1D_Add()
        {
            if (arr == null)
            {
                Console.WriteLine("\nОдномерный массив не инициализирован!\n");
                return;
            }
            int countNegNum;
            countNegNum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                    countNegNum++;
            }
            int[] local = new int[arr.Length + countNegNum];
            int i1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    local[i1] = arr[i];
                    local[i1 + 1] = Math.Abs(arr[i]);
                    Console.Write($"| {local[i1]} | {local[i1 + 1]} ");
                    i1 += 2;
                }
                if (arr[i] >= 0)
                {
                    local[i1] = arr[i];
                    Console.Write($"| {local[i1]} ");
                    i1 += 1;
                }
            }
            Console.WriteLine("|");
        }

        private static void Array_2D()
        {
            while (ShowMenu2D()) { }
        }

        private static bool ShowMenu2D()
        {
            Console.WriteLine(@"
:::::::::: Двумерный массив ::::::::::
--------------------------------------
1. Создать массив
2. Напечатать массив
3. Удалить все чётные столбцы 
--------------------------------------
0. Назад");
            switch (SelectAction("\nВведите номер действия: "))
            {
                case 1:
                    Console.WriteLine("\nФормирование двумерного массива\n");
                    int rows = Array2D_NumberOfRows("\nВведите количество строк: ");
                    int cols = Array2D_NumberOfCols("\nВведите количество столбцов: ");
                    arr2 = new int[rows, cols];
                    Array2D_Fill();
                    return true;
                case 2:
                    Console.WriteLine("\nДвумерный массив:\n ");
                    Array2D_Print();
                    return true;
                case 3:
                    Console.WriteLine("\nОбновлённый двумерный массив:\n ");
                    Array2D_DelCol();
                    return true;
                case 0:
                    return false;
                default:
                    return true;
            }
        }
               
        private static void Array2D_Fill()
        {
            Console.WriteLine("\nВыберите способ формирования двумерного массива:\n1. Вручную\n2. С помощью класса Random\n");
            switch (ReadInt_FillArray("\nВведите номер действия: "))
            {
                case 1:
                    for (int i = 0; i < arr2.GetLength(0); i++)
                        for (int j = 0; j < arr2.GetLength(1); j++)
                            arr2[i, j] = ReadInt($"Элемент [{i},{j}]:  ");
                    break;
                case 2:
                    for (int i = 0; i < arr2.GetLength(0); i++)
                        for (int j = 0; j < arr2.GetLength(1); j++)
                            arr2[i, j] = rnd.Next(-51, 51);
                    break;
            }
        }

        private static void Array2D_Print()
        {
            if (arr2 == null)
            {
                Console.WriteLine("\nДвумерный массив не инициализирован!\n");
                return;
            }
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    Console.Write($"|{arr2[i, j],3} ");
                }
                Console.WriteLine("|");
            }
        }

        private static void Array2D_DelCol()
        {
            if (arr2 == null)
            {
                Console.WriteLine("\nДвумерный массив не инициализирован!\n");
                return;
            }
            int[,] newArr2 = new int[arr2.GetLength(0), arr2.GetLength(1)];
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    if (j % 2 == 0)
                    {
                        newArr2[i, j / 2] = arr2[i, j];
                        Console.Write($"|{newArr2[i, j / 2], 3} ");
                    }
                }
                Console.WriteLine("|");
            }
            arr2 = newArr2;
        }

        private static void raggedArray()
        {
            while (ShowMenuRaggedArray()) { }
        }

        private static bool ShowMenuRaggedArray()
        {
            Console.WriteLine(@"
:::::::::: Рваный массив ::::::::::
-----------------------------------
1. Создать массив
2. Напечатать массив
3. Добавить К строк, начиная с номера N
-----------------------------------
0. Назад");
            switch (SelectAction("\nВведите номер действия: "))
            {
                case 1:
                    Console.WriteLine("\nФормирование рваного массива\n");
                    int rows3 = jaggedArray_NumberOfRows("\nВведите количество строк: ");
                    arr3 = new int[rows3][];
                    jaggedArray_Fill();
                    return true;
                case 2:
                    if (arr3 == null)
                    {
                        Console.WriteLine("\nРваный массив не инициализирован!\n");
                    }
                    else
                        jaggedArray_Print();
                    return true;
                case 3:
                    if (arr3 == null)
                    {
                        Console.WriteLine("\nРваный массив не инициализирован!\n");
                    }
                    else
                    {
                        Console.WriteLine("\nДобавить K строк, начиная с номера N\n");
                        int k = ReadK("\nВведите количество строк для добавления (K): ");
                        int n = ReadN("\nВведите номер строки, с которой начать добавление строк (N): ");
                        jaggedArray_AddRows(k, n);
                    }
                    return true;
                case 0:
                    return false;
                default:
                    return true;
            }
        }          
    
        private static void jaggedArray_Fill()
        {
            int cols3;
            Console.WriteLine("\nВыберите способ формирования рваного массива:\n1. Вручную\n2. С помощью класса Random");

            switch (ReadInt_FillArray("\nВведите номер действия: "))
            {
                case 1:
                    for (int i = 0; i < arr3.Length; i++)
                    {
                        cols3 = jaggedArray_NumberOfCols($"Введите количество столбцов {i+1}-й строке рваного массива: ");
                        arr3[i] = new int[cols3];
                        for (int j = 0; j < cols3; j++)
                            arr3[i][j] = ReadInt($"Элемент [{i},{j}]:  ");
                    }
                    break;

                case 2:
                    for (int i = 0; i < arr3.Length; i++)
                    {
                        cols3 = jaggedArray_NumberOfCols($"Введите количество столбцов в {i+1}-й строке рваного массива: ");
                        arr3[i] = new int[cols3];
                        for (int j = 0; j < cols3; j++)
                            arr3[i][j] = rnd.Next(-51, 51);
                    }
                    break;
                default:
                    break;
            }
        }

        private static void jaggedArray_Print()
        {
            if (arr3 == null)
            {
                Console.WriteLine("\nРваный массив не инициализирован!\n");
                return;
            }

            else
            {
                for (int i = 0; i < arr3.Length; i++)
                {
                    for (int j = 0; j < arr3[i].Length; j++)
                    {
                        Console.Write($"|{arr3[i][j],3} ");
                    }
                    Console.WriteLine("|");
                }
            }
        }

        private static void jaggedArray_AddRows(int k, int n)
        {
            if (arr3 == null)
            {
                Console.WriteLine("\nРваный массив не инициализирован!\n");
                return;
            }

            int[][] newArr3 = new int[arr3.Length + k][];
            for (int i = 0; i < newArr3.Length; i++)
            {
                if  (i <= n)
                {
                    newArr3[i] = new int[arr3[i].Length];
                    newArr3[i] = arr3[i];
                }
                if (i < n + k && i + 1 > n)
                {
                    Console.WriteLine($"\nВыберите способ формирования {i + 1}-й строки рваного массива:\n1. Вручную\n2. С помощью класса Random");
                    switch (ReadInt_FillArray("\nВведите номер действия: "))
                    {
                        case 1:
                            int newCols3_case1 = jaggedArray_NumberOfCols($"Введите количество столбцов в {i + 1}-й строке: ");
                            int[] nums_case1 = new int[newCols3_case1];
                            for (int j = 0; j < newCols3_case1; j++)
                                 arr3[i][j] = ReadInt($"Элемент [{i},{j}]:  ");
                            newArr3[i] = nums_case1;
                            break;

                        case 2:
                            int newCols3_case2 = jaggedArray_NumberOfCols($"Введите количество столбцов в {i + 1}-й строке: ");
                            int[] nums_case2 = new int[newCols3_case2];
                            for (int i1 = 0; i1 < newCols3_case2; i1++)
                                nums_case2[i1] = rnd.Next(-51, 51);
                            newArr3[i] = nums_case2;
                            break;
                    }
                }
                if (i >= n + k)
                {
                    newArr3[i] = new int[arr3[i-k].Length];
                    newArr3[i] = arr3[i-k];
                }
            }
            Console.WriteLine("\nОбновлённый массив:");
            for (int i = 0; i < newArr3.Length; i++)
            {
                for (int j = 0; j < newArr3[i].Length; j++)
                {
                    Console.Write($"|{newArr3[i][j], 3} ");
                }
                Console.WriteLine("|");
            }
        }

        private static int ReadInt(string str = "")
        {
            int size;
            bool b;
            do
            {
                Console.Write(str);
                b = int.TryParse(Console.ReadLine(), out size);
                if (b == false)
                {
                    Console.WriteLine("\nНекорректный ввод! Пожалуйста, повторите попытку!\n");
                }
            }
            while (b == false);

            return size;
        }

        private static int Array1D_Size(string str)
        {
            int size;
            bool b;
            do
            {
                Console.Write(str);
                b = int.TryParse(Console.ReadLine(), out size);
                if (b == false)
                {
                    Console.WriteLine("\nНекорректный ввод! Пожалуйста, повторите попытку!\n");
                }
                if (b == true && size < 1)
                {
                    Console.WriteLine($"\nОшибка: размер одномерного массива не может быть < 1! Повторите попытку!\n");
                    b = false;
                }
            }
            while (b == false);

            return size;
        }

        private static int Array2D_NumberOfRows(string str)
        {
            int size;
            bool b;
            do
            {
                Console.Write(str);
                b = int.TryParse(Console.ReadLine(), out size);
                if (b == false)
                {
                    Console.WriteLine("\nНекорректный ввод! Пожалуйста, повторите попытку!\n");
                }
                if (b == true && size < 1)
                {
                    Console.WriteLine($"\nОшибка: количество строк двумерного массива не может быть < 1! Повторите попытку!\n");
                    b = false;
                }
            }
            while (b == false);

            return size;
        }
        private static int Array2D_NumberOfCols(string str)
        {
            int size;
            bool b;
            do
            {
                Console.Write(str);
                b = int.TryParse(Console.ReadLine(), out size);
                if (b == false)
                {
                    Console.WriteLine("\nНекорректный ввод! Пожалуйста, повторите попытку!\n");
                }
                if (b == true && size < 1)
                {
                    Console.WriteLine($"\nОшибка: количество столбцов двумерного массива не может быть < 1! Повторите попытку!\n");
                    b = false;
                }
            }
            while (b == false);

            return size;
        }


        private static int jaggedArray_NumberOfRows(string str)
        {
            int size;
            bool b;
            do
            {
                Console.Write(str);
                b = int.TryParse(Console.ReadLine(), out size);
                if (b == false)
                {
                    Console.WriteLine("\nНекорректный ввод! Пожалуйста, повторите попытку!\n");
                }
                if (b == true && size < 1)
                {
                    Console.WriteLine($"\nОшибка: количество строк рваного массива не может быть < 1! Повторите попытку!\n");
                    b = false;
                }
            }
            while (b == false);

            return size;
        }
        private static int jaggedArray_NumberOfCols(string str)
        {
            int size;
            bool b;
            do
            {
                Console.Write(str);
                b = int.TryParse(Console.ReadLine(), out size);
                if (b == false)
                {
                    Console.WriteLine("\nНекорректный ввод! Пожалуйста, повторите попытку!\n");
                }
                if (b == true && size < 1)
                {
                    Console.WriteLine($"\nОшибка: количество столбцов в рванном массиве не может быть < 1! Повторите попытку!\n");
                    b = false;
                }
            }
            while (b == false);

            return size;
        }

        private static int ReadK(string str)
        {
            int size;
            bool b;
            do
            {
                Console.Write(str);
                b = int.TryParse(Console.ReadLine(), out size);
                if (b == false)
                {
                    Console.WriteLine("\nНекорректный ввод! Пожалуйста, повторите попытку!\n");
                }
                if (b == true && size < 1)
                {
                    Console.WriteLine($"\nОшибка: количество строк для добавления не может быть < 1! Повторите попытку!\n");
                    b = false;
                }
            }
            while (b == false);

            return size;
        }

        private static int ReadN(string str)
        {
            int size;
            bool b;
            do
            {
                Console.Write(str);
                b = int.TryParse(Console.ReadLine(), out size);
                if (b == false)
                {
                    Console.WriteLine("\nНекорректный ввод! Пожалуйста, повторите попытку!\n");
                }
                if (b == true && size < 1)
                {
                    Console.WriteLine($"\nОшибка: введённый номер строки не может быть < 1! Повторите попытку!\n");
                    b = false;
                }
            }
            while (b == false);

            return size;
        }

        private static int SelectAction(string str, int min = 0, int max = 3)
        {
            int size;
            bool b;
            do
            {
                Console.Write(str);
                b = int.TryParse(Console.ReadLine(), out size);
                if (b == false)
                {
                    Console.WriteLine("\nНекорректный ввод! Пожалуйста, повторите попытку!\n");
                }
                if ((size < min) || (size > max))
                {
                    Console.WriteLine($"\nОшибка: введённое значение не входит в диапазон допустимых значений [{min};{max}]! Повторите попытку!\n");
                    b = false;
                }
            }
            while (b == false);

            return size;
        }


        private static int ReadInt_FillArray(string str, int min = -1, int max = -1)
        {
            int size;
            bool b;
            do
            {
                Console.Write(str);
                b = int.TryParse(Console.ReadLine(), out size);
                if (b == false)
                {
                    Console.WriteLine("\nНекорректный ввод! Пожалуйста, повторите попытку!\n");
                }
                if ((min != -1 && size < min) || (max != -1 && max < size))
                {
                    Console.WriteLine($"\nОшибка: введённое значение не входит в диапазон допустимых значений [{min};{max}]\n");
                    b = false;
                }
            }
            while (b == false);

            return size;
        }
    }
}
        