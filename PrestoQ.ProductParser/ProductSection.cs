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

//var promoSplitPrice = new NumberFormatter(96,8,line).Value;
//var split = new  NumberFormatter(114,8,line).Value;
    }
}