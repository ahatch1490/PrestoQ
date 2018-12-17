using System.Runtime.CompilerServices;

namespace PrestoQ.ProductParser
{
    public class TaxRate
    {

        private const int TAX_FLAG_INDEX = 4; 
        private const int FLAGS_INDEX = 123;
        private const int LENGTH = 8; 
        private const decimal TAX = 0.7775m; 
        private readonly FlagParser _parser; 
        public TaxRate(FlagParser parser)
        {
            _parser = parser; 
        }

        public bool IsTaxable(ProductSection section)
        {
            return _parser.GetFlag(section.ValueAt(FLAGS_INDEX, LENGTH), TAX_FLAG_INDEX); 
        }
       
        public decimal Parse(ProductSection section)
        {
            return IsTaxable(section) ? TAX : 0.00m;
        }
    }
}