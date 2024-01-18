using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ProductDescriptionProcessor.Processor
{
    public interface IColorProcessor : IProcessorHandler
    { }

    public class ColorProcessor : ProcessorChainHandler, IColorProcessor, ITransientDependency
    {
        private readonly List<string> COLORS = new List<string>()
        {
            "Black",
"Silver",
"Gunmetal",
"Bronze",
"Gold",
"White",
"Red",
"Blue",
"Green",
"Yellow",
"Charcoal",
"Chrome",
"Satin black",
"Satin silver",
"Satin gunmetal",
"Satin bronze",
"Satin gold",
"Matte black",
"Matte gray",
"Matte white",
"Dark Anthracite"
        };

        public (bool, string) IsContainData(ProductSpliterResult result)
        {
            foreach (string color in COLORS)
            {
                if (result.ProductDescription.Contains(color))
                {
                    return (true, color);
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
                    result.Product.Color = data;
                    result.ProcessorApplied.Add(data, nameof(ColorProcessor));
                    result.ParseProductDescription(data);
                }
                else
                {
                    result.ProcessorsNotFound.Add(nameof(ColorProcessor));
                }
                return base.ProcessAsync(result);
            }
            catch (Exception ex)
            {
                result.ProcessorsError.Add(nameof(ColorProcessor), ex.Message);
            }
            return base.ProcessAsync(result);
        }

        private bool IsColorName(string name) {
            var predefined = typeof(System.Drawing.Color).GetProperties(BindingFlags.Public | BindingFlags.Static);
            return predefined.Any(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase)) || COLORS.Contains(name);
        }
    }
}

