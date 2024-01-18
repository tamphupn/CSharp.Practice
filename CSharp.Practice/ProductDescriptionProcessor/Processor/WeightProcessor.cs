using System;
namespace ProductDescriptionProcessor.Processor
{
    public interface IWeightProcessor : IProcessorHandler
    { }

    public class WeightProcessor : ProcessorChainHandler, IWeightProcessor
    {
        private readonly List<string> WEIGHT_UNITS = new List<string>()
        {
            "kg",
            "g"
        };

        public (bool, string, decimal) IsContainData(IList<string> splitedDatas)
        {
            foreach (var data in splitedDatas)
            {
                foreach (var unit in WEIGHT_UNITS)
                {
                    if (data.EndsWith(unit))
                    {
                        decimal weight = 0;
                        bool isSuccess= Decimal.TryParse(data.Replace(unit, string.Empty), out weight);
                        if (isSuccess)
                        {
                            return (true, data, weight);
                        }
                    }
                }
            }

            return (false, string.Empty, 0);
        }

        public override Task<ProductSpliterResult> ProcessAsync(ProductSpliterResult result)
        {
            try
            {
                (bool isExisted, string data, decimal weight) = IsContainData(result.SplitedDatas);
                if (isExisted)
                {
                    var parseData = data.Remove(0, 2);
                    result.Product.Weight = weight;
                    result.ProcessorApplied.Add(data, nameof(OffsetProcessor));
                    result.ParseProductDescription(data);
                }
                else
                {
                    result.ProcessorsNotFound.Add(nameof(OffsetProcessor));
                }
            }
            catch (Exception ex)
            {
                result.ProcessorApplied.Add(nameof(OffsetProcessor), ex.Message);
            }

            return base.ProcessAsync(result);
        }
    }
}

