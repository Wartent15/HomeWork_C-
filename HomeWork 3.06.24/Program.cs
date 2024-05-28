using System;
using System.Collections;

class Builder : IComparable
{
    public int YearBuilt { get; set; }
    public int OfficeCount { get; set; }
    public double TotalArea { get; set; }

    public int CompareTo(object obj)
    {
        Builder otherBuilder = (Builder)obj;
        return this.YearBuilt.CompareTo(otherBuilder.YearBuilt);
    }
}

class SortOfficceBuilderComparer : IComparer
{
    public int Compare(object x, object y)
    {
        Builder builder1 = (Builder)x;
        Builder builder2 = (Builder)y;
        return builder1.OfficeCount.CompareTo(builder2.OfficeCount);
    }
}

class SortAreaBuilderComparer : IComparer
{
    public int Compare(object x, object y)
    {
        Builder builder1 = (Builder)x;
        Builder builder2 = (Builder)y;
        return builder1.TotalArea.CompareTo(builder2.TotalArea);
    }
}

class Program
{
    static void Main()
    {
        ArrayList builders = new ArrayList();

        builders.Add(new Builder { YearBuilt = 2000, OfficeCount = 50, TotalArea = 1000 });
        builders.Add(new Builder { YearBuilt = 1998, OfficeCount = 30, TotalArea = 800 });
        builders.Add(new Builder { YearBuilt = 2010, OfficeCount = 100, TotalArea = 2000 });

        builders.Sort(); // Сортировка по году постройки
        Console.WriteLine("Сортировка по году постройки:");
        foreach (Builder builder in builders)
        {
            Console.WriteLine($"Год постройки: {builder.YearBuilt}");
        }

        builders.Sort(new SortOfficceBuilderComparer()); // Сортировка по количеству офисов
        Console.WriteLine("\nСортировка по количеству офисов:");
        foreach (Builder builder in builders)
        {
            Console.WriteLine($"Количество офисов: {builder.OfficeCount}");
        }

        builders.Sort(new SortAreaBuilderComparer()); // Сортировка по общей площади
        Console.WriteLine("\nСортировка по общей площади:");
        foreach (Builder builder in builders)
        {
            Console.WriteLine($"Общая площадь: {builder.TotalArea}");
        }
    }
}