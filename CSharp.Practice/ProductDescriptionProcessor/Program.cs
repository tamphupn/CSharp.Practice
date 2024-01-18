using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ProductDescriptionProcessor.Processor;

namespace ProductDescriptionProcessor;
class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
               .AddTransient<IOffsetProcessor, OffsetProcessor>()
               .AddTransient<IDimensionProcessor, DimensionProcessor>()
               .AddTransient<IColorProcessor, ColorProcessor>()
               .AddTransient<IDescriptionProcessor, DescriptionProcessor>()
               .AddTransient<IBrandProcessor, BrandProcessor>()
               .AddTransient<IWeightProcessor, WeightProcessor>()
               .AddScoped<IImportProductDescriptionProcessor, ImportProductDescriptionProcessor>()
               .BuildServiceProvider();


        var offsetProcessorHandler = serviceProvider.GetRequiredService<IOffsetProcessor>();
        var dimensionProcessorHandler = serviceProvider.GetRequiredService<IDimensionProcessor>();
        var colorProcessorHandler = serviceProvider.GetRequiredService<IColorProcessor>();
        var descriptionProcessorHandler = serviceProvider.GetRequiredService<IDescriptionProcessor>();
        var brandProcessor = serviceProvider.GetRequiredService<IBrandProcessor>();
        var weightProcessor = serviceProvider.GetRequiredService<IWeightProcessor>();
        ImportProductDescriptionProcessor importProductDescriptionProcessor = new ImportProductDescriptionProcessor(offsetProcessorHandler, dimensionProcessorHandler, colorProcessorHandler, descriptionProcessorHandler, brandProcessor, weightProcessor);

        //string productData = "A-620127;245/45R19 102W Westlake SA57";
        List<string> products = new List<string>()
        {
            "D1-195154;11,75x22,5 Stålfelg Last ET120 ND",
            "RW3170;Røwde 11.5/80-15.3 asdbas asfasf",
            "D1-248256;125/80R15 Firestone Rad",
            "A-445412;6,5X16/42 Xtreme VN5 5-108 CB 65,1 Dark Anthracite",
            "D1-2000030;Silopro 40 Transp/Grønn 0,04 16x50  29,44kg"
        };
        var result = importProductDescriptionProcessor.Processor(products).Result;

        foreach (var res in result)
        {
            Console.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Console.WriteLine("======");
        }

    }
}

