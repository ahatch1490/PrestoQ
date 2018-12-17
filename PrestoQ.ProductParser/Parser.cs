using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static PrestoQ.ProductParser.PropertyParser;
[assembly:InternalsVisibleTo("PrestoQ.ProductParser.Test")]    
namespace PrestoQ.ProductParser
{
    public static class Parser
    {
        
        public static List<Product> GetProducts(string data)
        {
            var products = new List<Product>();
            using (var strReader = new StringReader(data))
            {
                var line = string.Empty; 
                
                while ((line = strReader.ReadLine()) != null)
                {
                    if (ValidProductLine(line))
                    {
                        products.Add( 
                            CreateProduct(line)
                        );
                    }
                }
            }
            return products;
        }
        
        private static Product CreateProduct(string line)
        {
            var section = new ProductSection(line); 
            var numberFormatter = new NumberFormatter();
            var priceFormatter = new PriceFormatter();
            var flagParser = new FlagParser();
            return new Product
            {
                
                ProductId = new ProductId(numberFormatter).ToInt(section), 
                Description = new ProductDescription().parse(section),
                RegularSingularPrice = new RegularPrice(numberFormatter,priceFormatter).Parse(section).ToString(),
                PromotionalSingularPrice =  new PromotionalPrice(numberFormatter,priceFormatter).Parse(section).ToString(),
                RegularSplitPrice = new RegularPriceSplitCalculator(numberFormatter,priceFormatter).Parse(section).ToString(),
                PromotionalSplitPrice = new PromotionalPriceSplitCalculator(numberFormatter,priceFormatter).Parse(section).ToString(),
                TaxRate = new TaxRate(flagParser).Parse(section).ToString(), 
                UnitOfMeasure = new UnitOfMeasure(flagParser).Parse(section),
                Size = new ProductSize().Parse(section),
                RawData = line
            }; 
        }
        
        private static bool ValidProductLine(string line)
        {
            return ! string.IsNullOrWhiteSpace(line); 
        }

    }
}