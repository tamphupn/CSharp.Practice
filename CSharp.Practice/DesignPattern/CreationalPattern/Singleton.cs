﻿using System;
namespace DesignPattern.CreationalPattern
{
	public class Singleton
	{
		static Singleton instance;

		protected Singleton()
		{
		}

		public static Singleton Instance()
		{
			if (instance == null)
			{
				instance = new Singleton();
			}

			return instance;
		}
	}

	public class SingletonResult
	{
		public static void Run()
		{
			Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

			if (s1 == s2)
			{
				Console.WriteLine("Same Instance");
			}
        }
	}
}

