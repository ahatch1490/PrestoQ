﻿using System.Collections.Generic;
using System.IO;
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
            return new Product
            {
                
                ProductId = new ProductId(numberFormatter).ToInt(section), 
                Description = new ProductDescription().parse(section),
                RegularSingularPrice = new RegularPrice(numberFormatter,priceFormatter).Parse(section).ToString(),
                PromotionalSingularPrice = PromotionalSingularPrice(line).ToString(),
                RegularSplitPrice = GetRegularSplitPrice(line).ToString(),
                PromotionalSplitPrice = GetPromotionalSplitPrice(line).ToString(),
                TaxRate = GetTaxRate(line).ToString(),
                UnitOfMeasure = GetUnitOfMeasure(line),
                Size = GetProductSize(line)
            }; 
        }
        
        private static bool ValidProductLine(string line)
        {
            return ! string.IsNullOrWhiteSpace(line); 
        }

    }
}