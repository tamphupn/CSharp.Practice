using System;
using System.Reflection;

namespace ProductDescriptionProcessor.Processor
{
    public interface IBrandProcessor : IProcessorHandler
    { }

    public class BrandProcessor : ProcessorChainHandler, IBrandProcessor, ITransientDependency
    {
        private readonly List<string> BRANDS = new List<string>()
        {
            "Nokian",
            "Xtreme",
            "Firestone"
        };

        public (bool, string) IsContainData(ProductSpliterResult result)
        {
            foreach (string brand in BRANDS)
            {
                if (result.ProductDescription.Contains(brand))
                {
                    return (true, brand);
                }
            }

            return (false, string.Empty);
        }

        public override Task<ProductSpliterResult> ProcessAsync(ProductSpliterResult result)
        {
            try
            {
                (bool isExisted, string data) = IsContainData(result);
                if (isExisted)
                {
                    result.Product.Brand = data;
                    result.ProcessorApplied.Add(data, nameof(BrandProcessor));
                    result.ParseProductDescription(data);
                }
                else
                {
                    result.ProcessorsNotFound.Add(nameof(BrandProcessor));
                }
                return base.ProcessAsync(result);
            }
            catch (Exception ex)
            {
                result.ProcessorsError.Add(nameof(BrandProcessor), ex.Message);
            }
            return base.ProcessAsync(result);
        }

        private bool IsContains(string name)
        {
            return  BRANDS.Contains(name);
        }
    }
}

