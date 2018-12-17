using System.Xml.Schema;

namespace PrestoQ.ProductParser
{
    public class ProductSection
    {
        private readonly string _product;

        public ProductSection(string product)
        {
            _product = product; 
        }
    
        public string ValueAt(int start, int length)
        {
           return _product.Substring(start, length); 
        }

        public string all()
        {
            return _product; 
        }

    }
}