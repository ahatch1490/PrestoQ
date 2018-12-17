using System;

namespace PrestoQ.ProductParser
{
    public class RegularPriceSplitCalculator : PriceSplitBase
    {
        
        private const int START_INDEX = 87;
        private const int SPLIT_INDEX = 105;
        private const int LENGTH = 8;

        protected override int StartIndex()=> START_INDEX;
        protected override int SplitIndex()=> SPLIT_INDEX;
        protected override int Length()=> LENGTH;

        public RegularPriceSplitCalculator(NumberFormatter numberFormatter, PriceFormatter priceFormatter) : base(numberFormatter, priceFormatter)
        {
        }
    }
}