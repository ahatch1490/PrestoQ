using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PrestoQ.ProductParser
{
    public class Parser
    {
        private const decimal TAX = 0.7775m; 
        private const int WEIGHT_INDEX = 2; 
        private const int TAXABLE_INDEX = 4; 
        
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

        private static bool IsLastProduct(string line)
        {
            return line == null;
        }

        private static bool ValidProductLine(string line)
        {
            return ! string.IsNullOrWhiteSpace(line); 
        }

        private static Product CreateProduct(string line)
        {
            return new Product
            {
                ProductID = GetProductID(line),
                Description = GetDescription(line),
                RegularSingularPrice = GetRegularSingularPrice(line),
                PromotionalSingularPrice = PromotionalSingularPrice(line),
                RegularSplitPrice = GetRegularSplitPrice(line),
                PromotionalSplitPrice = GetPromotionalSplitPrice(line),
                TaxRate = GetTaxRate(line),
                UnitOfMeasure = GetUnitOfMeasure(line),
                Size = GetProductSize(line)
            }; 
        }

        private static string GetDescription(string line)
        {
            return line.Substring(9,59).Trim();
        }

        private static int GetProductID(string line)
        {
            var id = FormatNumber(0, 8, line); 
            return Convert.ToInt32(id); 
        }

        private static decimal GetRegularSingularPrice(string line)
        {
            var regPrice = FormatNumber(69, 8, line); 
            return string.IsNullOrWhiteSpace(regPrice) ? 0.00m : FormatPrice(regPrice);
        }
        
        private static decimal FormatPrice(string value)
        {
            var lastIndex = value.Length - 2;
            var price = value.Insert(lastIndex, ".");
            return decimal.Parse(price); 
        }
        
        private static decimal PromotionalSingularPrice(string line)
        {
            var promoPrice = FormatNumber(78, 8, line); 
            return string.IsNullOrWhiteSpace(promoPrice) ? 0.00m : FormatPrice(promoPrice);        
        }
        
        private static decimal GetRegularSplitPrice(string line)
        {
            var regSplitPrice = FormatNumber(87, 8, line);
            var split = FormatNumber(105, 8, line);

            if (string.IsNullOrWhiteSpace(regSplitPrice) || string.IsNullOrWhiteSpace(regSplitPrice))
            {
                return 0.00m; 
            }
            return FormatSplitPrice(FormatPrice(regSplitPrice),decimal.Parse(split));  
        }
        
        private static decimal GetPromotionalSplitPrice(string line)
        {
            var promoSplitPrice = line.Substring(96,8).TrimStart('0');
            var split = line.Substring(114, 8).TrimStart('0');

            if (string.IsNullOrWhiteSpace(promoSplitPrice) || string.IsNullOrWhiteSpace(promoSplitPrice))
            {
                return 0.00m; 
            }
            return FormatSplitPrice(FormatPrice(promoSplitPrice),decimal.Parse(split));  
        }

        private static decimal GetTaxRate(string line)
        {
            return GetFlag(line, TAXABLE_INDEX) ? TAX : 0.00m;
        }
        
        private static string GetUnitOfMeasure(string line)
        {
            var measure = "Each";
            if (GetFlag(line,WEIGHT_INDEX))
            {
                measure = "Pound"; 
            }
            return measure; 
        }

        private static  bool GetFlag(string line, int flagIndex)
        {
            var flags = line.Substring(123, 8);
            if (string.IsNullOrWhiteSpace(flags))
            {
                return false;
            }

            return flags[flagIndex] == 'Y';
        }

        private static decimal FormatSplitPrice(decimal regSplitPrice, decimal split)
        {
            return Math.Round(regSplitPrice / split, 4);
        }
        
        private static string GetProductSize(string line)
        {
            return line.Substring(134, 8).Trim();
        }

        private static string FormatNumber(int start, int length, string line)
        {
            return line.Substring(start, length).TrimStart('0');
        }
 
    }
}