using System;
namespace DesignPattern.BehaviorPattern
{
    /*
    - Chain of responsibility
    - this pattern avoids coupling between the sender request and the response. it will split the process into multiple handler in a chains, and each of the chain will process or send it into next chain, until we have a object handle this request
     */
	public abstract class Handler
	{
		protected Handler _successor;


		public void SetSuccessor(Handler successor)
		{
			_successor = successor;
		}

		public abstract void Process(int request);
	}

	public class ConcreteHandler1: Handler
	{
		public override void Process(int request)
		{
            if (request >= 0 && request < 10)
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            }
            else if (_successor != null)
            {
                _successor.Process(request);
            }
        }
	}

    public class ConcreteHandler2 : Handler
    {
        public override void Process(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            }
            else if (_successor != null)
            {
                _successor.Process(request);
            }
        }
    }

    public class ChainOfResponsibilityResult
	{
        public static void Run()
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            h1.SetSuccessor(h2);

            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (var request in requests)
            {
                h1.Process(request);
            }
        }
	}
}

