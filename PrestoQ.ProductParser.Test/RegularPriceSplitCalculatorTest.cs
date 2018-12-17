using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class RegularPriceSplitCalculatorTest
    {
        private string line =
            "14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz";

        [Fact]
        public void ShouldReturnSplitPrice()
        {
            var split = new RegularPriceSplitCalculator(new NumberFormatter(), new PriceFormatter());
            var price = split.Parse(new ProductSection(line)); 
            Assert.Equal(6.50m,price);
        }
        
    }
    
}