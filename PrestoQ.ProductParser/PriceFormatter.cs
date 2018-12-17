namespace PrestoQ.ProductParser
{
    public class PriceFormatter
    {
       
        private decimal CreatePrice(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return 00.00m;
            }
            
            var lastIndex = number.Length - 2;
            var price = number.Insert(lastIndex, ".");
            return decimal.Parse(price); 
        }

        public decimal Parse(string number)
        {
            return CreatePrice(number);
        }
    }
}