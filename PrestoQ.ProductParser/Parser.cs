using System;
using System.Collections.Generic;
using System.IO;

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
                                Description = GetDescription(line)
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
            var  id = line.Substring(0,8);
            return Convert.ToInt32(id.TrimStart('0')); 
        }
    }
}