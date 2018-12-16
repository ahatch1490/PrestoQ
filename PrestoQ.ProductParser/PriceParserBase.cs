using System;

namespace PrestoQ.ProductParser
{
    public abstract class PriceParserBase
    {
        private readonly NumberFormatter _numberFormatter;
        private readonly PriceFormatter _priceFormatter;

        protected virtual int StartIndex()=> throw new NotImplementedException();
        protected virtual int Length()=> throw new NotImplementedException();


        protected PriceParserBase(NumberFormatter numberFormatter, PriceFormatter priceFormatter)
        {
            _numberFormatter = numberFormatter;
            _priceFormatter = priceFormatter; 
        }
        public decimal Parse(ProductSection productSection)
        {
            var regPrice = _numberFormatter.parse(productSection.ValueAt(StartIndex(), Length()));
            return string.IsNullOrWhiteSpace(regPrice) ? 0.00m : _priceFormatter.Parse(regPrice);  //(regPrice).Value;
        }
    }
}