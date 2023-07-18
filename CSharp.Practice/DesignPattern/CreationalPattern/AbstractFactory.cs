using System;
namespace DesignPattern.CreationalPattern
{
	public abstract class AbstractProductA
	{

	}

	public abstract class AbstractProductB
	{
        public abstract void Interact(AbstractProductA a);
    }

	public class ProductA1 : AbstractProductA
	{

	}

	public class ProductB1 : AbstractProductB
	{
        public override void Interact(AbstractProductA a)
		{
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }

    public class ProductA2 : AbstractProductA
    {

    }

    public class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }

    public abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    public class ConcreteFactory1: AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    public class Client
	{
		private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;

		public Client(AbstractFactory factory)
		{
            _abstractProductA = factory.CreateProductA();
            _abstractProductB = factory.CreateProductB();
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }


	public class AbstractFactoryResult
	{
		public static void Run()
		{
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();
        }
	}
}

