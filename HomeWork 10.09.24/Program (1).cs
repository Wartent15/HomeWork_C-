using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Задание 1:");
        Task1();

        Console.WriteLine("\nЗадание 2:");
        Task2();

        Console.WriteLine("\nЗадание 3:");
        Task3();

        Console.WriteLine("\nЗадание 4:");
        Task4();

        Console.WriteLine("\nЗадание 5:");
        Task5();

        Console.WriteLine("\nЗадание 6:");
        Task6();

        Console.WriteLine("\nЗадание 7:");
        Task7();
    }

    static void Task1()
    {
        // Одномерный массив
        int[] A = new int[5];
        Console.WriteLine("Введите 5 чисел для массива A:");
        for (int i = 0; i < 5; i++)
        {
            A[i] = int.Parse(Console.ReadLine());
        }

        // Двумерный массив
        int[,] B = new int[3, 4];
        Random random = new Random();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                B[i,j] = random.Next(1100);
            }
        }

        // Вывод массивов
        Console.WriteLine("Массив A:");
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write(A[i] + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Массив B:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(B[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Поиск максимума, минимума, суммы
        int maxA = A[0], minA = A[0], sumA = 0, evenSumA = 0;
        double maxB = B[0, 0], minB = B[0, 0], sumB = 0, productB = 1;

        for (int i = 0; i < 5; i++)
        {
            if (A[i] > maxA) maxA = A[i];
            if (A[i] < minA) minA = A[i];
            sumA += A[i];
            if (A[i] % 2 == 0) evenSumA += A[i];
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (B[i, j] > maxB) maxB = B[i, j];
                if (B[i, j] < minB) minB = B[i, j];
                sumB += B[i, j];
                productB *= B[i, j];
            }
        }

        Console.WriteLine($"Максимум в A: {maxA}, минимум в A: {minA}, сумма A: {sumA}, четные в A: {evenSumA}");
        Console.WriteLine($"Максимум в B: {maxB}, минимум в B: {minB}, сумма B: {sumB}, произведение B: {productB}");
    }

    static void Task2()
    {
        int[,] arr = new int[5, 5];
        Random random = new Random();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                arr[i, j] = random.Next(-100, 101);
            }
        }

        int min = arr[0, 0], max = arr[0, 0];
        int minIndex = 0, maxIndex = 0, sum = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (arr[i, j] < min)
                {
                    min = arr[i, j];
                    minIndex = i * 5 + j;
                }
                if (arr[i, j] > max)
                {
                    max = arr[i, j];
                    maxIndex = i * 5 + j;
                }
            }
        }

        int start = Math.Min(minIndex, maxIndex);
        int end = Math.Max(minIndex, maxIndex);

        for (int i = start + 1; i < end; i++)
        {
            sum += arr[i / 5, i % 5];
        }

        Console.WriteLine($"Сумма между min и max: {sum}");
    }

    static void Task3()
    {
        Console.WriteLine("Введите строку для шифрования:");
        string text = Console.ReadLine();
        Console.WriteLine("Введите сдвиг:");
        int shift = int.Parse(Console.ReadLine());

        string encrypted = "";
        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            if (char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                encrypted += (char)((c + shift - baseChar) % 26 + baseChar);
            }
            else
            {
                encrypted += c;
            }
        }

        Console.WriteLine("Зашифрованная строка: " + encrypted);
    }

    static void Task4()
    {
        int[,] matrix = new int[2, 2];
        Random random = new Random();
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                matrix[i, j] = random.Next(1, 10);
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Введите число для умножения матрицы:");
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                matrix[i, j] *= number;
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Task5()
    {
        Console.WriteLine("Введите арифметическое выражение (например, 5 + 3 - 2):");
        string expression = Console.ReadLine();
        string[] parts = expression.Split(' ');
        int result = int.Parse(parts[0]);

        for (int i = 1; i < parts.Length; i += 2)
        {
            string op = parts[i];
            int num = int.Parse(parts[i + 1]);
            if (op == "+")
            {
                result += num;
            }
            else if (op == "-")
            {
                result -= num;
            }
        }

        Console.WriteLine("Результат: " + result);
    }

    static void Task6()
    {
        Console.WriteLine("Введите текст:");
        string text = Console.ReadLine();
        char[] arr = text.ToCharArray();

        bool newSentence = true;
        for (int i = 0; i < arr.Length; i++)
        {
            if (newSentence && char.IsLetter(arr[i]))
            {
                arr[i] = char.ToUpper(arr[i]);
                newSentence = false;
            }
            if (arr[i] == '.' || arr[i] == '!' || arr[i] == '?')
            {
                newSentence = true;
            }
        }

        Console.WriteLine(new string(arr));
    }

    static void Task7()
    {
        Console.WriteLine("Введите текст:");
        string text = Console.ReadLine();
        Console.WriteLine("Введите недопустимое слово:");
        string forbiddenWord = Console.ReadLine();

        string replacedText = text.Replace(forbiddenWord, "***");
        int count = (text.Length - replacedText.Length) / forbiddenWord.Length;

        Console.WriteLine("Результат: " + replacedText);
        Console.WriteLine("Количество замен: " + count);
    }
}
