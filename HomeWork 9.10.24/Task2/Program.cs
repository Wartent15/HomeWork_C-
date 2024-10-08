using System.Reflection;

[AttributeUsage(AttributeTargets.Property)]
public class ValidationAttribute : Attribute
{
    public bool IsRequired { get; }

    public ValidationAttribute(bool isRequired)
    {
        IsRequired = isRequired;
    }
}
public class User
{
    [Validation(true)]
    public string Name { get; set; }

    [Validation(false)]
    public string Email { get; set; }
}
public static class Validator
{
    public static bool Validate<T>(T obj)
    {
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            var attr = property.GetCustomAttribute<ValidationAttribute>();
            if (attr != null && attr.IsRequired)
            {
                var value = property.GetValue(obj) as string;
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine($"Property {property.Name} is required.");
                    return false;
                }
            }
        }
        return true;
    }
}
class Program
{
    static void Main(string[] args)
    {
        var user = new User { Name = "", Email = "user@example.com" };

        if (!Validator.Validate(user))
        {
            Console.WriteLine("User validation failed.");
        }
        else
        {
            Console.WriteLine("User is valid.");
        }

        user.Name = "John Doe";

        if (Validator.Validate(user))
        {
            Console.WriteLine("User is valid.");
        }
    }
}