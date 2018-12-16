namespace PrestoQ.ProductParser
{
    public class ProductDescription
    {
        private const int START_INDEX = 9;
        private const int LENGTH = 59;
        
        public string parse(ProductSection productSection)
        {
            return productSection.ValueAt(START_INDEX,LENGTH).Trim();
        }
    }
}