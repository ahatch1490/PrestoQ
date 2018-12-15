using System;

namespace PrestoQ.ProductParser
{
    internal static class PropertyParser
    {
        private const decimal TAX = 0.7775m; 
        private const int WEIGHT_INDEX = 2; 
        private const int TAXABLE_INDEX = 4; 
        
        public static string GetDescription(string line)
        {
            return line.Substring(9,59).Trim();
        }

        public static int GetProductId(string line)
        {
            var id = new NumberFormatter(0, 8, line).Value; 
            return Convert.ToInt32(id); 
        }

        public static decimal GetRegularSingularPrice(string line)
        {
            var regPrice = new NumberFormatter(69, 8, line).Value; 
            return string.IsNullOrWhiteSpace(regPrice) ? 0.00m : new PriceFormatter(regPrice).Value;
        }
        
        public static decimal PromotionalSingularPrice(string line)
        {
            var promoPrice = new NumberFormatter(78, 8, line).Value; 
            return string.IsNullOrWhiteSpace(promoPrice) ? 0.00m : new PriceFormatter(promoPrice).Value;        
        }
        
        public static decimal GetRegularSplitPrice(string line)
        {
            var regSplitPrice = new NumberFormatter(87, 8, line).Value;
            var split = new NumberFormatter(105, 8, line).Value;

            if (string.IsNullOrWhiteSpace(regSplitPrice) || string.IsNullOrWhiteSpace(split))
            {
                return 0.00m; 
            }
            return SplitPrice(new PriceFormatter(regSplitPrice).Value,decimal.Parse(split));  
        }
        
        public static decimal GetPromotionalSplitPrice(string line)
        {
            var promoSplitPrice = new NumberFormatter(96,8,line).Value;
            var split = new  NumberFormatter(114,8,line).Value;

            if (string.IsNullOrWhiteSpace(promoSplitPrice) || string.IsNullOrWhiteSpace(split))
            {
                return 0.00m; 
            }
            return SplitPrice(new PriceFormatter(promoSplitPrice).Value, decimal.Parse(split));  
        }

        public static decimal GetTaxRate(string line)
        {
            return GetFlag(line, TAXABLE_INDEX) ? TAX : 0.00m;
        }
        
        public static string GetUnitOfMeasure(string line)
        {
            var measure = "Each";
            if (GetFlag(line,WEIGHT_INDEX))
            {
                measure = "Pound"; 
            }
            return measure; 
        }
        
        public static string GetProductSize(string line)
        {
            return line.Substring(134, 8).Trim();
        }

        private static  bool GetFlag(string line, int flagIndex)
        {
            var flags = line.Substring(123, 8);
            if (string.IsNullOrWhiteSpace(flags))
            {
                return false;
            }

            return flags[flagIndex] == 'Y';
        }
        
        private static decimal SplitPrice(decimal price, decimal split)
        {
            return Math.Round(price / split, 4);
        }
    }
}