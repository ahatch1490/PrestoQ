using System;

namespace PrestoQ.ProductParser
{
    public class SplitPricing
    {      
        public decimal Calculate(decimal price, decimal split)
        {
            return Math.Round(price / split, 4);
        }
    }
}