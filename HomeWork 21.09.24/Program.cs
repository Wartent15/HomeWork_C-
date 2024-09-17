using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {

        int K1 = 5, K2 = 10;
        var A = new List<int> { 1, 6, 3, 7, 8 };
        var B = new List<int> { 12, 9, 3, 15, 5 };

        var result1 = A.Where(x => x > K1).Concat(B.Where(x => x < K2)).OrderBy(x => x).ToList();

        Console.WriteLine("Результат первой задачи:");
        foreach (var num in result1)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        var sequence = new List<int> { 123, 45, -7, 85, 12, -33, 74, 45, 9 };
        var result2 = sequence.Where(x => x > 0).Select(x => x % 10).Distinct().ToList();

        Console.WriteLine("Последние цифры без повторений:");
        foreach (var digit in result2)
        {
            Console.Write(digit + " ");
        }
        Console.WriteLine();
    }
}
