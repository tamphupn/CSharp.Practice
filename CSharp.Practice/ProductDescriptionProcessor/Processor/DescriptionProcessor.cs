using System;
using System.Reflection;

namespace ProductDescriptionProcessor.Processor
{
    public interface IDescriptionProcessor : IProcessorHandler
    { }

    public class DescriptionProcessor : ProcessorChainHandler, IDescriptionProcessor, ITransientDependency
    {
        public override Task<ProductSpliterResult> ProcessAsync(ProductSpliterResult result)
        {
            try
            {
                List<string> remaining = new List<string>();
                foreach (var data in result.SplitedDatas)
                {
                    if (!result.ProcessorApplied.ContainsKey(data))
                    {
                        remaining.Add(data);
                    }
                }
                if (remaining.Any())
                {
                    result.Product.Description = string.Join(' ', remaining);
                    result.ProcessorApplied.Add(result.Product.Description, nameof(DescriptionProcessor));
                }
                else
                {
                    result.ProcessorsNotFound.Add(nameof(DescriptionProcessor));
                }

                return base.ProcessAsync(result);
            }
            catch (Exception ex)
            {
                result.ProcessorsError.Add(nameof(DescriptionProcessor), ex.Message);
            }
            return base.ProcessAsync(result);
        }
    }
}

