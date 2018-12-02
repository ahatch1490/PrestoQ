using System.IO;
using PrestoQ.ProductParser;
using Newtonsoft.Json; 
namespace PrestoQ.Cmd
{
    public class ProductService
    {
        public void Save(Product product)
        {
            var json = JsonConvert.SerializeObject(product);
            using(var f =  File.Open("product-output.json", FileMode.Append,FileAccess.Write))
            {
                if (f.CanWrite)
                {
                    using (var w = new StreamWriter(f))
                    {
                        w.Write(json);
                    }
                }
                else
                {
                    throw new IOException("Unable to write to file product-output.json"); 
                }
            }
        }
    }
}