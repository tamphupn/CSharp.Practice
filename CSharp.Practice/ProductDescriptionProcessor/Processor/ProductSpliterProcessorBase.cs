using System;
namespace ProductDescriptionProcessor.Processor
{
    public class ProductSpliterResult
    {
        public IDictionary<string, string> ProcessorApplied { get; set; }
        public IDictionary<string, string> ProcessorsError { get; set; } = new Dictionary<string, string>();
        public IList<string> ProcessorsNotFound { get; set; } = new List<string>();
        public ImportProductDto Product { get; set; }
        public IList<string> SplitedDatas { get; set; }
        public string ProductDescription { get; set; }

        public ProductSpliterResult()
        {
            ProcessorApplied = new Dictionary<string, string>();
            ProcessorsError = new Dictionary<string, string>();
            ProcessorsNotFound = new List<string>();
            Product = new ImportProductDto();
            SplitedDatas = new List<string>();
        }

        public ProductSpliterResult(IDictionary<string, string> processorApplied, ImportProductDto product, string productDescription)
        {
            ProcessorApplied = processorApplied;
            Product = product;
            ProductDescription = productDescription;
            SplitedDatas = productDescription.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList();
        }

        public void ParseProductDescription(string data)
        {
            ProductDescription = ProductDescription.Replace(data, string.Empty);
            SplitedDatas = ProductDescription.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList();
        }

    }
	public interface IProcessorHandler
	{
        Task<ProductSpliterResult> ProcessAsync(ProductSpliterResult result);
        IProcessorHandler SetNextProcessor(IProcessorHandler successor);
    }

    public abstract class ProcessorChainHandler : IProcessorHandler
    {
        private IProcessorHandler _handler = default!;

        public virtual Task<ProductSpliterResult> ProcessAsync(ProductSpliterResult result)
        {
            if (_handler != null)
            {
                return _handler.ProcessAsync(result);
            }
            else
            {
                return Task<ProductSpliterResult>.Factory.StartNew(() => result);
            }
        }

        public IProcessorHandler SetNextProcessor(IProcessorHandler successor)
        {
            _handler = successor;
            return successor;
        }
    }
}

