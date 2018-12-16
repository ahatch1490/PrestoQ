namespace PrestoQ.ProductParser
{
    public class PromotionalPrice : PriceParserBase
    {
        
        private const int START_INDEX = 78;
        private const int LENGTH = 8;

        protected override int StartIndex()=> START_INDEX;
        protected override int Length()=> LENGTH; 

        public PromotionalPrice(NumberFormatter numberFormatter, PriceFormatter priceFormatter) : base(numberFormatter, priceFormatter)
        {
        }
        
    }
}