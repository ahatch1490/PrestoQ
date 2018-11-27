using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace PrestoQ.ProductParser
{
    public class Parser
    {
        public static List<Product> GetProducts(string data)
        {
            var products = new List<Product>();
            using (var strReader = new StringReader(data))
            {
                
                while (true)
                {
                    var line = strReader.ReadLine();
                    if (line != null)
                    {
                        
                        products.Add(
                            new Product
                            {
                                ProductID = GetProductID(line),
                                Description = GetDescription(line),
                                RegularSingularPrice = GetRegularSingularPrice(line)
                                
                            }
                        );
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return products;
        }

        private static string GetDescription(string line)
        {
            return line.Substring(9,59).Trim();
        }

        private static int GetProductID(string line)
        {
            var id = line.Substring(0,8);
            return Convert.ToInt32(id.TrimStart('0')); 
        }

        private static decimal GetRegularSingularPrice(string line)
        {
            var regPrice = line.Substring(69,8).TrimStart('0');
            return string.IsNullOrWhiteSpace(regPrice) ? 0.00m : FormatPrice(regPrice);
        }
        
        private static decimal FormatPrice(string value)
        {
            var lastIndex = value.Length - 2;
            var price = value.Insert(lastIndex, ".");
            return Decimal.Parse(price); 
        }
    }
}