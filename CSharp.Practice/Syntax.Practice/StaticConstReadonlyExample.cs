using System;
namespace Syntax.Practice
{
	public class StaticConstReadonlyExample
	{
		public readonly int ReadOnlyValue = 1;
		public const int ConstValue = 1;
		public static int StaticValue = 1;

		public void Print()
		{
			Console.WriteLine($@"Readonly {ReadOnlyValue}");
            Console.WriteLine($@"Const {ConstValue}");
            Console.WriteLine($@"Static {StaticValue}");
        }
		public StaticConstReadonlyExample()
		{
			Print();
            ReadOnlyValue = 2;
			// ConstValue = 2; // error
            StaticValue = 2;
			Print();
        }

		public void ChangeStatic()
		{
			StaticValue = 3;
			// ReadOnlyValue = 4; error
        }
	}
}