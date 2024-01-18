using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProductDescriptionProcessor.Processor
{
	public interface IImportProductDescriptionProcessor
    {
		Task<IList<ProductSpliterResult>> Processor(IList<string> products, char splitCharacter = ' ', char skuCharacterSplit = ';');
	}

    public class ImportProductDescriptionProcessor : IImportProductDescriptionProcessor
    {
        private readonly IOffsetProcessor _offsetProcessor;
        private readonly IDimensionProcessor _dimensionProcessor;
        private readonly IColorProcessor _colorProcessor;
        private readonly IDescriptionProcessor _descriptionProcessor;
        private readonly IBrandProcessor _brandProcessor;
        private readonly IWeightProcessor _weightProcessor;

        private readonly List<IProcessorHandler> _chainOfProcessors;
        private IProcessorHandler _handler = default!;

        public ImportProductDescriptionProcessor(
            IOffsetProcessor offsetProcessor,
            IDimensionProcessor dimensionProcessor,
            IColorProcessor colorProcessor,
            IDescriptionProcessor descriptionProcessor,
            IBrandProcessor brandProcessor,
            IWeightProcessor weightProcessor)
        {
            _offsetProcessor = offsetProcessor ?? throw new ArgumentNullException(nameof(offsetProcessor));
            _dimensionProcessor = dimensionProcessor ?? throw new ArgumentNullException(nameof(dimensionProcessor));
            _colorProcessor = colorProcessor ?? throw new ArgumentNullException(nameof(colorProcessor));
            _descriptionProcessor = descriptionProcessor ?? throw new ArgumentNullException(nameof(descriptionProcessor));
            _brandProcessor = brandProcessor ?? throw new ArgumentNullException(nameof(brandProcessor));
            _weightProcessor = weightProcessor ?? throw new ArgumentNullException(nameof(weightProcessor));

            _chainOfProcessors = new List<IProcessorHandler>()
            {
                _brandProcessor,
                _dimensionProcessor,
                _offsetProcessor,
                _colorProcessor,
                _weightProcessor
            };

            PrepareProcessor();
        }

        public async Task<IList<ProductSpliterResult>> Processor(IList<string> products, char splitCharacter = ' ', char skuCharacterSplit = ';')
        {
            List<ProductSpliterResult> productProcessed = new List<ProductSpliterResult>();
            foreach (var content in products)
            {
                string[] splitSku = content.Split(skuCharacterSplit);
                if (splitSku.Length > 1)
                {
                    var importProduct = new ImportProductDto();
                    importProduct.SkuCode = splitSku[0].Trim();

                    ProductSpliterResult result = new ProductSpliterResult(new Dictionary<string, string>(), importProduct, splitSku[1]);
                    var res = await _handler.ProcessAsync(result);

                    productProcessed.Add(res);
                }
            }

            return productProcessed;
        }

        private void PrepareProcessor()
        {
            var _curr = _chainOfProcessors[0];
            _handler = _curr;
            for (int i = 1; i < _chainOfProcessors.Count; i++)
            {
                _curr = _curr.SetNextProcessor(_chainOfProcessors[i]);
            }
            _curr.SetNextProcessor(_descriptionProcessor);
        }
    }
}

