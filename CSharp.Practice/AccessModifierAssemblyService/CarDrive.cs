using System;
namespace AccessModifierAssemblyService
{
	public class CarDrive
	{
		private int Size { get; set; }
		public string Name { get; set; }
		protected string No { get; set; }
	}

	public class BwmCarDrive: CarDrive
    {
		public BwmCarDrive()
		{
			Console.WriteLine(this.Name);
		}
	}
}

