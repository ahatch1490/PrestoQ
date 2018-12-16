namespace PrestoQ.ProductParser
{
    public class PriceFormatter
    {
        public decimal Value { get; }
        

        public PriceFormatter(string number = "0000")
        {
            Value = CreateNumber(number); 

        }

        private decimal CreateNumber(string number)
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
            return CreateNumber(number);
        }
    }
}