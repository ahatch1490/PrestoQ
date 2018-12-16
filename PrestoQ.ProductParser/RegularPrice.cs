namespace PrestoQ.ProductParser
{
    public class RegularPrice : PriceParserBase
    {
        private const int START_INDEX = 69;
        private const int LENGTH = 8;

        protected override int StartIndex()=> START_INDEX;
        protected override int Length()=> LENGTH; 
        
        public RegularPrice(NumberFormatter numberFormatter, PriceFormatter priceFormatter) : base(numberFormatter, priceFormatter)
        {
        }
    }
}