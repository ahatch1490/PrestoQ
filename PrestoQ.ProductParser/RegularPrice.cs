namespace PrestoQ.ProductParser
{
    public class RegularPrice
    {
        private readonly NumberFormatter _numberFormatter;
        private readonly PriceFormatter _priceFormatter;
        private const int START_INDEX = 69;
        private const int LENGTH = 8;


        public RegularPrice(NumberFormatter numberFormatter, PriceFormatter priceFormatter)
        {
            _numberFormatter = numberFormatter;
            _priceFormatter = priceFormatter; 
        }
        public decimal Parse(ProductSection productSection)
        {
            var regPrice = _numberFormatter.parse(productSection.ValueAt(START_INDEX, LENGTH));
            return string.IsNullOrWhiteSpace(regPrice) ? 0.00m : _priceFormatter.Parse(regPrice);  //(regPrice).Value;
        }
    }
}