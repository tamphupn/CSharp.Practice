using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public interface ICarService
    {
        void Process();
    }

    public interface ITransientCarService: ICarService { }
    public interface IScopedCarService : ICarService { }
    public interface ISingletonCarService : ICarService { }
    public interface ITransientTwoCarService : ICarService { }

    public class TransientCarService: ITransientCarService
    {
        private Guid No { get; set; }

		public TransientCarService()
		{
            No = Guid.NewGuid();
            Console.WriteLine($@"{nameof(TransientCarService)} was created - Set No = {No}");
        }

        public void Process()
        {
            Console.WriteLine($@"{nameof(TransientCarService)} - Process = {No}");
        }
    }

    public class TransientTwoCarService : ITransientCarService
    {
        private Guid No { get; set; }

        public TransientTwoCarService()
        {
            No = Guid.NewGuid();
            Console.WriteLine($@"{nameof(TransientTwoCarService)} was created - Set No = {No}");
        }

        public void Process()
        {
            Console.WriteLine($@"{nameof(TransientTwoCarService)} - Process = {No}");
        }
    }

    public class ScopedCarService : IScopedCarService
    {
        private Guid No { get; set; }

        public ScopedCarService()
        {
            No = Guid.NewGuid();
            Console.WriteLine($@"{nameof(ScopedCarService)} was created - Set No = {No}");
        }

        public void Process()
        {
            Console.WriteLine($@"{nameof(ScopedCarService)} - Process = {No}");
        }
    }

    public class SingletonCarService : ISingletonCarService
    {
        private Guid No { get; set; }

        public SingletonCarService()
        {
            No = Guid.NewGuid();
            Console.WriteLine($@"{nameof(SingletonCarService)} was created - Set No = {No}");
        }

        public void Process()
        {
            Console.WriteLine($@"{nameof(SingletonCarService)} - Process = {No}");
        }
    }

    public class DependencyTest
    {
        public static void Run()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<ITransientCarService, TransientCarService>()
                .AddTransient<ITransientCarService, TransientTwoCarService>()
                .AddScoped<IScopedCarService, ScopedCarService>()
                .AddSingleton<ISingletonCarService, SingletonCarService>()
                .BuildServiceProvider();

            var serviceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();

            Console.WriteLine("=== Registed service collection ===");
            

            using (var scope = serviceScopeFactory.CreateScope())
            {
                Console.WriteLine("=== REQUEST ONE ===");
                var _transientCarService = scope.ServiceProvider.GetService<ITransientCarService>() ?? throw new ArgumentNullException(nameof(ITransientCarService));
                _transientCarService.Process();
                var _transientCarServiceTwo = scope.ServiceProvider.GetService<ITransientCarService>() ?? throw new ArgumentNullException(nameof(ITransientCarService));
                _transientCarServiceTwo.Process();

                var _scopedCarService = scope.ServiceProvider.GetService<IScopedCarService>() ?? throw new ArgumentNullException(nameof(IScopedCarService));
                _scopedCarService.Process();
                var _scopedCarServiceTwo = scope.ServiceProvider.GetService<IScopedCarService>() ?? throw new ArgumentNullException(nameof(IScopedCarService));
                _scopedCarServiceTwo.Process();

                var singletonService = scope.ServiceProvider.GetService<ISingletonCarService>() ?? throw new ArgumentNullException(nameof(ISingletonCarService));
                singletonService.Process();
            }

            using (var scopeTwo = serviceScopeFactory.CreateScope())
            {
                Console.WriteLine("=== REQUEST TWO ===");
                var _transientCarService = scopeTwo.ServiceProvider.GetService<ITransientCarService>() ?? throw new ArgumentNullException(nameof(ITransientCarService));
                _transientCarService.Process();
                var _transientCarServiceTwo = scopeTwo.ServiceProvider.GetService<ITransientCarService>() ?? throw new ArgumentNullException(nameof(ITransientCarService));
                _transientCarServiceTwo.Process();

                var _scopedCarService = scopeTwo.ServiceProvider.GetService<IScopedCarService>() ?? throw new ArgumentNullException(nameof(IScopedCarService));
                _scopedCarService.Process();
                var _scopedCarServiceTwo = scopeTwo.ServiceProvider.GetService<IScopedCarService>() ?? throw new ArgumentNullException(nameof(IScopedCarService));
                _scopedCarServiceTwo.Process();

                var singletonService = scopeTwo.ServiceProvider.GetService<ISingletonCarService>() ?? throw new ArgumentNullException(nameof(ISingletonCarService));
                singletonService.Process();
            }

            /*
             * Example output
=== Registed service collection ===
=== REQUEST ONE ===
TransientTwoCarService was created - Set No = d646b23c-756d-4754-ac93-122eea2b8e7e
TransientTwoCarService - Process = d646b23c-756d-4754-ac93-122eea2b8e7e
TransientTwoCarService was created - Set No = 494164b8-4690-4794-8b7d-ff5fed690e1f
TransientTwoCarService - Process = 494164b8-4690-4794-8b7d-ff5fed690e1f
ScopedCarService was created - Set No = 80e1cf69-a39f-4543-b24d-1899912eff94
ScopedCarService - Process = 80e1cf69-a39f-4543-b24d-1899912eff94
ScopedCarService - Process = 80e1cf69-a39f-4543-b24d-1899912eff94
SingletonCarService was created - Set No = a3dfea38-9811-4585-92b9-d25d597ba382
SingletonCarService - Process = a3dfea38-9811-4585-92b9-d25d597ba382
=== REQUEST TWO ===
TransientTwoCarService was created - Set No = 58cf4275-dc85-4f23-844c-e4d3ed6566e9
TransientTwoCarService - Process = 58cf4275-dc85-4f23-844c-e4d3ed6566e9
TransientTwoCarService was created - Set No = d0544e55-f186-4f5a-a973-f4b10519a68b
TransientTwoCarService - Process = d0544e55-f186-4f5a-a973-f4b10519a68b
ScopedCarService was created - Set No = 7ad1e3e2-d874-4e10-bb75-c87b971b9c1e
ScopedCarService - Process = 7ad1e3e2-d874-4e10-bb75-c87b971b9c1e
ScopedCarService - Process = 7ad1e3e2-d874-4e10-bb75-c87b971b9c1e
SingletonCarService - Process = a3dfea38-9811-4585-92b9-d25d597ba382

             */

        }
    }
}

