using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите ваше имя:");
        string name = Console.ReadLine();
        Console.WriteLine("Введите вашу фамилию:");
        string secondname = Console.ReadLine();
        Console.WriteLine("Введите ваш возраст:");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите ваш рост:");
        double height = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите ваш вес:");
        double weight = Convert.ToDouble(Console.ReadLine());
        // a
        string результат = "Имя: " + name + ", Фамилия: " + secondname + ", Возраст: " + age + ", Рост: " + height + ", Вес: " + weight;
        Console.WriteLine(результат);
        // б
        Console.WriteLine("Имя: {0}, Фамилия: {1}, Возраст: {2}, Рост: {3}, Вес: {4}", name, secondname, age, height, weight);
        // в
        Console.WriteLine($"Имя: {name}, Фамилия: {secondname}, Возраст: {age}, Рост: {height}, Вес: {weight}");

        // 2
        Console.WriteLine("Введите ваш вес в килограммах:");
        double m = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите ваш рост в метрах:");
        double h = Convert.ToDouble(Console.ReadLine());

        double IMT = m / (h * h);
        Console.WriteLine($"Индекс массы тела: {IMT}");

        // 3
        double x1 = 1, y1 = 2, x2 = 4, y2 = 6;
        double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        Console.WriteLine($"Расстояние между точками: {r:F2}");

        // 4
        Console.WriteLine("Введите число:");
        int num1 = Convert.ToInt32(Console.ReadLine());

        if (num1 % 2 == 0)
        {
            Console.WriteLine("Число четное");
        }
        else
        {
            Console.WriteLine("Число нечетное");
        }


        // 5
        Console.WriteLine("Введите число:");
        int n = Convert.ToInt32(Console.ReadLine());
        int sum = 0;

        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }

        Console.WriteLine($"Сумма чисел от 1 до {n}: {sum}");


        // 6
        Console.WriteLine("Введите число:");
        int num = Convert.ToInt32(Console.ReadLine());
        bool sim = true;

        if (num <= 1)
        {
            sim = false;
        }
        else
        {
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    sim = false;
                    break;
                }
            }
        }

        if (sim)
        {
            Console.WriteLine("Число простое");
        }
        else
        {
            Console.WriteLine("Число не простое");
        }
    }
}
