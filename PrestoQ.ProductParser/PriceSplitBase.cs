using System;
using System.IO;

namespace PrestoQ.ProductParser
{
    public abstract class PriceSplitBase
    {
        protected virtual int StartIndex()=> throw new NotImplementedException();
        protected virtual int SplitIndex()=> throw new NotImplementedException();
        protected virtual int Length()=> throw new NotImplementedException();
        
        protected readonly NumberFormatter _numberFormatter;
        protected readonly PriceFormatter _priceFormatter;

        protected PriceSplitBase(NumberFormatter numberFormatter, PriceFormatter priceFormatter)
        {
            _numberFormatter = numberFormatter;
            _priceFormatter =  priceFormatter;
        }
        
        public decimal Parse(ProductSection productSection)
        {
            var splitPrice = _numberFormatter.parse(productSection.ValueAt(StartIndex(),Length()));
            var split = _numberFormatter.parse(productSection.ValueAt(SplitIndex(),Length()));
            
            if (string.IsNullOrWhiteSpace(splitPrice) || string.IsNullOrWhiteSpace(split))
            {
                return 0.00m; 
            }
            return SplitPrice(_priceFormatter.Parse(splitPrice),decimal.Parse(split));  
        }
        
        private  decimal SplitPrice(decimal price, decimal split)
        {
            return Math.Round(price / split, 4);
        }
    }
}