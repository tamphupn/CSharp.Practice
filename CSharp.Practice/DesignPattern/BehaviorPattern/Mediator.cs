using System;
namespace DesignPattern.BehaviorPattern
{
	/*
	- Mediator Pattern
	- This pattern defines an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping obejct from referring to each other explicitly, and it lets you varu their interraction independently
	 */
	public abstract class Colleague
	{
		protected Mediator _mediator;

		public Colleague(Mediator mediator)
		{
            _mediator = mediator;
		}
	}

	public abstract class Mediator
	{
		public abstract void Send(string message, Colleague colleage);
	}

	public class ConcreteColleage1: Colleague
	{
		public ConcreteColleage1(Mediator mediator): base(mediator)
		{
		}

		public void Send(string message)
		{
			_mediator.Send(message, this);
		}

		public void Notify(string message)
		{
			Console.WriteLine("Colleague get message: " + message);
		}
	}

    public class ConcreteColleage2 : Colleague
    {
        public ConcreteColleage2(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            _mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague get message: " + message);
        }
    }

	public class ConcreteMediator: Mediator
	{
		ConcreteColleage1 _colleage1;
        ConcreteColleage2 _colleage2;

		public ConcreteColleage1 Colleage1
		{
			set { _colleage1 = value; }
		}

        public ConcreteColleage2 Colleage2
        {
            set { _colleage2 = value; }
        }

        public override void Send(string message, Colleague colleage)
        {
            if (colleage == _colleage1)
            {
                _colleage2.Notify(message);
            }
            else
            {
                _colleage1.Notify(message);
            }
        }
    }

    public class MediatorResult
	{
		public static void Run()
		{
			ConcreteMediator mediator = new ConcreteMediator();

			ConcreteColleage1 c1 = new ConcreteColleage1(mediator);
            ConcreteColleage2 c2 = new ConcreteColleage2(mediator);

			mediator.Colleage1 = c1;
			mediator.Colleage2 = c2;

			c1.Send("Test ConcreteColleage1");
			c2.Send("Test ConcreteColleage2");
        }
	}
}

