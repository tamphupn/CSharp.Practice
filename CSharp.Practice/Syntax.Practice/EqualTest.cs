using System;
namespace Syntax.Practice
{
	public class Customer
	{
		public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null)
			{
				return false;
			}

			if (!(obj is Customer))
			{
				return false;
			}

			Customer parsedObject = (Customer)obj;
			return (parsedObject.Name == this.Name);
        }

		~Customer()
		{

		}
    }

	public class EqualTest
	{
		public static void Run()
		{
			Customer a = new Customer();
			a.Name = "Phu";

			Customer b = a;

			Console.WriteLine($@"a == b: {a == b}");
            Console.WriteLine($@"a equal b: {a.Equals(b)}");

            Customer a1 = new Customer();
            a1.Name = "Tam";

			Customer b1 = new Customer();
            GC.Collect(b1);
            b1.Name = "Tam";
			

            Console.WriteLine($@"a1 == b1: {a1 == b1}");
            Console.WriteLine($@"a1 equal b1: {a1.Equals(b1)}");
        }
	}
}

