using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("PrestoQ.ProductParser.Test")]    
namespace PrestoQ.ProductParser
{
    public class Parser
    {
        
       
        private readonly ProductParser _productParser; 
        
        public Parser()
        {
            // we should actually have a IoC container like Lamar for this stuff in real life
            var numberFormatter = new NumberFormatter();
            var priceFormatter = new PriceFormatter();
            var flagParser = new FlagParser();
            var productId = new ProductId(numberFormatter);
            var productDescription = new ProductDescription();
            var regularPrice = new RegularPrice(numberFormatter, priceFormatter);
            var promotionalPrice = new PromotionalPrice(numberFormatter, priceFormatter);
            var regularPriceSplitCalculator = new RegularPriceSplitCalculator(numberFormatter, priceFormatter);
            var promotionalPriceSplitCalculator = new PromotionalPriceSplitCalculator(numberFormatter, priceFormatter);
            var taxRate = new TaxRate(flagParser); 
            var productSize = new ProductSize();
            var unitOfMeasure = new UnitOfMeasure(flagParser);
            _productParser = new ProductParser(
                productId,
                productDescription,
                regularPrice,
                promotionalPrice,
                regularPriceSplitCalculator,
                promotionalPriceSplitCalculator,
                taxRate,productSize,
                unitOfMeasure);
            
        }
            
            
        public  List<Product> GetProducts(string data)
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
                            _productParser.Parse(new ProductSection(line))
                        );
                    }
                }
            }
            return products;
        }
        
       
        
        private  bool ValidProductLine(string line)
        {
            return ! string.IsNullOrWhiteSpace(line); 
        }

    }
}