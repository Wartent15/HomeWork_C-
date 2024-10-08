using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

[AttributeUsage(AttributeTargets.Property)]
public class ParamsAttribute : Attribute
{
    public string FileName { get; }

    public ParamsAttribute(string fileName)
    {
        FileName = fileName;
    }
}
public class Config
{
    [Params("config1.ini")]
    public string Setting1 { get; set; }

    [Params("config2.ini")]
    public int Setting2 { get; set; }

    [Params("config3.ini")]
    public bool Setting3 { get; set; }
}



public static class IniLoader
{
    public static void LoadProperties<T>(T obj)
    {
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            var attr = property.GetCustomAttribute<ParamsAttribute>();
            if (attr != null)
            {
                var values = LoadIniFile(attr.FileName);
                if (values.TryGetValue(property.Name, out var value))
                {
                    var convertedValue = Convert.ChangeType(value, property.PropertyType);
                    property.SetValue(obj, convertedValue);
                }
            }
        }
    }

    private static Dictionary<string, string> LoadIniFile(string fileName)
    {
        var values = new Dictionary<string, string>();
        foreach (var line in File.ReadLines(fileName))
        {
            if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith(";"))
            {
                var parts = line.Split('=');
                if (parts.Length == 2)
                {
                    values[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }
        return values;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var config = new Config();
        IniLoader.LoadProperties(config);

        Console.WriteLine($"Setting1: {config.Setting1}");
        Console.WriteLine($"Setting2: {config.Setting2}");
        Console.WriteLine($"Setting3: {config.Setting3}");
    }
}