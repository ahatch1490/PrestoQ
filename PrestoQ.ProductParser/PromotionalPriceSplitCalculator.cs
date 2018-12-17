namespace PrestoQ.ProductParser
{
    public class PromotionalPriceSplitCalculator : PriceSplitBase
    {
        private const int START_INDEX = 96;
        private const int SPLIT_INDEX = 114;
        private const int LENGTH = 8;

        protected override int StartIndex()=> START_INDEX;
        protected override int SplitIndex()=> SPLIT_INDEX;
        protected override int Length()=> LENGTH;

        public PromotionalPriceSplitCalculator(NumberFormatter numberFormatter, PriceFormatter priceFormatter) : base(numberFormatter, priceFormatter)
        {
        }
    }
}