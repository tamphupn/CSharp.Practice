using DesignPattern.BehaviorPattern;
using DesignPattern.CreationalPattern;
using DesignPattern.StruturalPattern;

namespace DesignPattern;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Abstract Factory");
        AbstractFactoryResult.Run();

        Console.WriteLine("Factory Method");
        FactoryMethodResult.Run();

        Console.WriteLine("Singleton");
        SingletonResult.Run();

        Console.WriteLine("Facade");
        FacadeResult.Run();

        Console.WriteLine("Chain of Responsibility");
        ChainOfResponsibilityResult.Run();

        Console.WriteLine("Mediator");
        MediatorResult.Run();
    }
}

