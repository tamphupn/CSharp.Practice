using System;
namespace DesignPattern.StruturalPattern
{
	public class SubSystemOne
	{
		public void MethodOne()
		{
			Console.WriteLine("Method Four");
		}
	}

    public class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine("Method Two");
        }
    }

    public class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine("Method Three");
        }
    }

    public class Facade
    {
        SubSystemOne _one;
        SubSystemTwo _two;
        SubSystemThree _three;

        public Facade()
        {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
        }

        public void MethodA()
        {
            Console.WriteLine("Method A");
            _one.MethodOne();
            _two.MethodTwo();
            _three.MethodThree();
        }
    }

    public class FacadeResult
	{
		public static void Run()
		{
            Facade facade = new Facade();
            facade.MethodA();

        }
	}
}