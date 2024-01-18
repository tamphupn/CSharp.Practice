namespace ProductDescriptionProcessor.Processor
{
    public interface IOffsetProcessor : IProcessorHandler
    { }

    public class OffsetProcessor : ProcessorChainHandler, IOffsetProcessor
    {
        private const string PREFIX = "ET";

        public (bool, string) IsContainData(IList<string> splitedDatas)
        {
            foreach (var data in splitedDatas)
            {
                if (data.StartsWith(PREFIX))
                {
                    return (true, data);
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
                    var parseData = data.Remove(0, 2);
                    result.Product.Offset = Convert.ToInt32(parseData);
                    result.ProcessorApplied.Add(data, nameof(OffsetProcessor));
                    result.ParseProductDescription(data);
                }
                else
                {
                    result.ProcessorsNotFound.Add(nameof(OffsetProcessor));
                }
            }
            catch(Exception ex)
            {
                result.ProcessorApplied.Add(nameof(OffsetProcessor), ex.Message);
            }
            
            return base.ProcessAsync(result);
        }
    }
}

