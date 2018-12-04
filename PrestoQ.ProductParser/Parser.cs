using System.Collections.Generic;
using System.IO;
using static PrestoQ.ProductParser.PropertyParser;

namespace PrestoQ.ProductParser
{
    public static class Parser
    {
        
        public static List<Product> GetProducts(string data)
        {
            var products = new List<Product>();
            using (var strReader = new StringReader(data))
            {
                while (true)
                {
                    var line = strReader.ReadLine();
                    
                    if (IsLastProduct(line))
                    {
                        break;
                    }
                    
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
            return new Product
            {
                ProductId = GetProductId(line),
                Description = GetDescription(line),
                RegularSingularPrice = GetRegularSingularPrice(line).ToString(),
                PromotionalSingularPrice = PromotionalSingularPrice(line).ToString(),
                RegularSplitPrice = GetRegularSplitPrice(line).ToString(),
                PromotionalSplitPrice = GetPromotionalSplitPrice(line).ToString(),
                TaxRate = GetTaxRate(line).ToString(),
                UnitOfMeasure = GetUnitOfMeasure(line),
                Size = GetProductSize(line)
            }; 
        }

        private static bool IsLastProduct(string line)
        {
            return line == null;
        }

        private static bool ValidProductLine(string line)
        {
            return ! string.IsNullOrWhiteSpace(line); 
        }

      

        
 
    }
}