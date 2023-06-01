namespace Reflection;

using System;

public interface IExampleInterface
{
    int InterfaceMethod(int par);
}

public class ExampleClass : IExampleInterface
{
    private int privateField;
    private static float StaticField;
    
    public static string PublicProperty { get; set; }
    
    public ExampleClass(int privateFieldValue)
    {
        privateField = privateFieldValue;
    }

    public int PublicMethod(int parameter)
    {
        return parameter * privateField;
    }

    private void PrivateMethod()
    {
        Console.WriteLine("Private method called");
    }

    public int InterfaceMethod(int par)
    {
        return par;
    }

    public static float StaticMethod()
    {
        Console.WriteLine("Static method called");
        return 1.0f;
    }
}

