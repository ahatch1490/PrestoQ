namespace PrestoQ.ProductParser
{
    public class ProductSize
    {
        
        public string Parse(ProductSection productSection)
        {
            return productSection.ValueAt(134, 8).Trim();
        }
    }
}