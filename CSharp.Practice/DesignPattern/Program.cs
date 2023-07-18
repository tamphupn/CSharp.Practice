using DesignPattern.CreationalPattern;

namespace DesignPattern;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Factory Method");
        FactoryMethodResult.Run();

        Console.WriteLine("Singleton");
        SingletonResult.Run();
    }
}

