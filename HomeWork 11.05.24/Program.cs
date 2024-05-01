using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Задание 1
        double[] A = new double[5];
        double[,] B = new double[3, 4];
        Random rand = new Random();

        Console.WriteLine("Введите элементы массива A:");
        for (int i = 0; i < A.Length; i++)
        {
            A[i] = Convert.ToDouble(Console.ReadLine());
        }

        Console.WriteLine("Массив A:");
        foreach (var i in A)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine("\n\nМассив B:");

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                B[i, j] = rand.NextDouble() * 100; // Заполнение случайными числами
                Console.Write(B[i, j] + "\t");
            }
            Console.WriteLine();
        }

        double maxA = A.Max();
        double minA = A.Min();
        double sumA = A.Sum();
        double productA = A.Aggregate(1.0, (acc, val) => acc * val);
        double sumEvenA = A.Where(x => x % 2 == 0).Sum();
        double sumOddColsB = 0;
        for (int j = 0; j < 4; j++)
        {
            if (j % 2 != 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    sumOddColsB += B[i, j];
                }
            }
        }

        // Задание 2
        int[,] array = new int[5, 5];
        int minIndexI = 0, minIndexJ = 0, maxIndexI = 0, maxIndexJ = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                array[i, j] = rand.Next(-100, 101);
                if (array[i, j] < array[minIndexI, minIndexJ])
                {
                    minIndexI = i;
                    minIndexJ = j;
                }
                if (array[i, j] > array[maxIndexI, maxIndexJ])
                {
                    maxIndexI = i;
                    maxIndexJ = j;
                }
            }
        }

        int sumBetweenMinMax = 0;
        int startI = Math.Min(minIndexI, maxIndexI) + 1;
        int endI = Math.Max(minIndexI, maxIndexI);
        int startJ = Math.Min(minIndexJ, maxIndexJ) + 1;
        int endJ = Math.Max(minIndexJ, maxIndexJ);

        for (int i = startI; i < endI; i++)
        {
            for (int j = startJ; j < endJ; j++)
            {
                sumBetweenMinMax += array[i, j];
            }
        }

        // Задание 3
        Console.WriteLine("\nВведите строку для шифрования шифром Цезаря:");
        string inputString = Console.ReadLine();
        int shift = 3; // сдвиг на 3 символа

        string encryptedString = string.Empty;
        foreach (char c in inputString)
        {
            if (char.IsLetter(c))
            {
                char shifted = (char)(c + shift);
                if ((char.IsLower(c) && shifted > 'z') || (char.IsUpper(c) && shifted > 'Z'))
                {
                    shifted = (char)(c - (26 - shift));
                }
                encryptedString += shifted;
            }
            else
            {
                encryptedString += c;
            }
        }

        Console.WriteLine($"Зашифрованная строка: {encryptedString}");

        // Дешифрование
        string decryptedString = string.Empty;
        foreach (char c in encryptedString)
        {
            if (char.IsLetter(c))
            {
                char shifted = (char)(c - shift);
                if ((char.IsLower(c) && shifted < 'a') || (char.IsUpper(c) && shifted < 'A'))
                {
                    shifted = (char)(c + (26 - shift));
                }
                decryptedString += shifted;
            }
            else
            {
                decryptedString += c;
            }
        }

        Console.WriteLine($"Расшифрованная строка: {decryptedString}");


        // Задание 4

        // Умножение матрицы на число
        double[,] matrix = new double[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
        double multiplier = 2;
        double[,] result1 = new double[2, 3];

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result1[i, j] = matrix[i, j] * multiplier;
            }
        }

        Console.WriteLine("\nУмножение матрицы на число:");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(result1[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Сложение матриц
        double[,] matrix1 = new double[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
        double[,] matrix2 = new double[2, 3] { { 7, 8, 9 }, { 10, 11, 12 } };
        double[,] sumMatrix = new double[2, 3];

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                sumMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        Console.WriteLine("\nСложение матриц:");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(sumMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Произведение матриц
        double[,] matrixA = new double[2, 2] { { 1, 2 }, { 3, 4 } };
        double[,] matrixB = new double[2, 2] { { 5, 6 }, { 7, 8 } };
        double[,] productMatrix = new double[2, 2];

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    productMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }

        Console.WriteLine("\nПроизведение матриц:");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write(productMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Задание 5

        string expression = Console.ReadLine();
        int result = 0;

        if (expression.Contains("+"))
        {
            string[] numbers = expression.Split('+');
            result = Convert.ToInt32(numbers[0]) + Convert.ToInt32(numbers[1]);
        }
        else if (expression.Contains("-"))
        {
            string[] numbers = expression.Split('-');
            result = Convert.ToInt32(numbers[0]) - Convert.ToInt32(numbers[1]);
        }

        Console.WriteLine($"\nРезультат арифметического выражения: {result}");

        // Задание 6

        string text = Console.ReadLine();
        string[] sentences = text.Split(". ");
        string resultText = "";

        foreach (var sentence in sentences)
        {
            if (!string.IsNullOrEmpty(sentence))
            {
                string updatedSentence = char.ToUpper(sentence[0]) + sentence.Substring(1);
                resultText += updatedSentence + ". ";
            }
        }

        Console.WriteLine("\nИзмененный текст: " + resultText);


        string text1 = "To be, or not to be, that is the question, Whether 'tis nobler in the mind to suffer " +
              "The slings and arrows of outrageous fortune, Or to take arms against a sea of troubles, " +
              "And by opposing end them? To die: to sleep; No more; and by a sleep to say we end " +
              "The heart-ache and the thousand natural shocks That flesh is heir to, 'tis a consummation " +
              "Devoutly to be wish'd. To die, to sleep";

        string forbiddenWord = "die";

        int replacedCount = 0; 

        string maskedText = MaskForbiddenWord(text1, forbiddenWord,   replacedCount);

        Console.WriteLine("Результат работы:");
        Console.WriteLine(maskedText);
        Console.WriteLine("Статистика: " + replacedCount + " замены слова " + forbiddenWord + ".");
    }

    static string MaskForbiddenWord(string text1, string forbiddenWord, int  replacedCount)
    {
        replacedCount = 0;
        string pattern = @"\b" + forbiddenWord + @"\b";
        string maskedText = Regex.Replace(text1, pattern, match =>
        {
            replacedCount++;
            return new string('*', match.Length);
        }, RegexOptions.IgnoreCase);

        return maskedText;
    }
}