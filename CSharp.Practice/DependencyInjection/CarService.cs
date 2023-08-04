using System;
using Microsoft.Extensions.DependencyInjection;
using static System.Formats.Asn1.AsnWriter;

namespace DependencyInjection
{
    public interface ICarService
    {
        void Process();
    }

    public interface ITransientCarService: ICarService { }
    public interface IScopedCarService : ICarService { }
    public interface ISingletonCarService : ICarService { }

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
                .AddTransient<ITransientCarService, TransientCarService>()
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
        }
    }
}

