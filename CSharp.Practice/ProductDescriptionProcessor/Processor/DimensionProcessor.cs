using System;
using System.Text.RegularExpressions;

namespace ProductDescriptionProcessor.Processor
{
    public interface IDimensionProcessor : IProcessorHandler
    { }

    public class DimensionProcessor : ProcessorChainHandler, IDimensionProcessor
    {
        private const string PATTERN = @"(\d+(\.\d+)?|\d+(\,\d+)?)[/\\x](\d+(\.\d+)?|\d+(\,\d+)?)[-/R\\x]?(\d+(\.\d+)?|\d+(\,\d+)?)?";

        public (bool, string) IsContainData(IList<string> splitedDatas)
        {
            foreach (string line in splitedDatas)
            {
                var match = Regex.Match(line, PATTERN);

                if (match.Success)
                {
                    return (true, line);
                }
            }

            return (false, string.Empty);
        }

        public override Task<ProductSpliterResult> ProcessAsync(ProductSpliterResult result)
        {
            try
            {
                (bool isExisted, string data) = IsContainData(result.SplitedDatas);
                if (isExisted)
                {
                    var match = Regex.Match(data, PATTERN);
                    result.Product.Width = match.Groups[1].Value.Replace(".", ",");
                    result.Product.Profile = match.Groups[4].Value.Replace(".", ",");
                    result.Product.Diameter = match.Groups[7].Value.Replace(".", ",");
                    
                    result.ProcessorApplied.Add(data, nameof(DimensionProcessor));
                    result.ParseProductDescription(data);
                }
                else
                {
                    result.ProcessorsNotFound.Add(nameof(DimensionProcessor));
                }
                return base.ProcessAsync(result);
            }
            catch(Exception ex)
            {
                result.ProcessorsError.Add(nameof(DimensionProcessor), ex.Message);
                return base.ProcessAsync(result);
            }
        }
    }
}

