using System;
using System.Reflection;


namespace Reflection;

using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        Type type = typeof(ExampleClass);
        object? instance = Activator.CreateInstance(type, 42);
        
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            var fieldValue = field.GetValue(instance);
            if (!field.IsStatic)
            {
                field.SetValue(instance, 1);
                Console.WriteLine($"  {field.Name} => {fieldValue}");
            }
        }
        
        foreach (PropertyInfo property in properties)
        {
            if (property.Name == "PublicProperty")
            {
                property.SetValue(instance, "Новое значение");
                Console.WriteLine($"{property.Name} => {property.GetValue(instance)}");
            }
        }
        
        Console.WriteLine(methods.Length);
        foreach (MethodInfo method in methods)
        {
            if (!method.IsStatic && !method.IsPrivate)
            {
                Console.WriteLine($"Резульат: {method.Name}");
            }
        }
    }
}

