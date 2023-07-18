using System;
namespace DesignPattern.CreationalPattern
{
	/*
	- Creational Pattern: Factory Method
	- This pattern will define an interface for creating an object, but let subclasses decide which class to instantiate
	- This pattern lets a class defer instantiation to subclasses
	*/
	public abstract class Product { }

	/// <summary>
	/// Define instance of product A
	/// </summary>
	public class ProductA: Product
	{

	}

    /// <summary>
    /// Define instance of product B
    /// </summary>
    public class ProductB: Product
	{

	}

	/// <summary>
	/// Define factory method
	/// </summary>
	public abstract class Creator
	{
		public abstract Product FactoryMethod();
	}

    public class CreatorProductA : Creator
    {
        public override Product FactoryMethod()
        {
            Console.WriteLine("Init product A");
            return new ProductA();
        }
    }

    public class CreatorProductB : Creator
    {
        public override Product FactoryMethod()
        {
			Console.WriteLine("Init product B");
            return new ProductB();
        }
    }

    public class FactoryMethodResult
	{
		public static void Run()
		{
			List<Creator> creators = new List<Creator>()
			{
				new CreatorProductA(),
				new CreatorProductB()
			};

			foreach (var creator in creators)
			{
				creator.FactoryMethod();
			}
		}
	}
}

