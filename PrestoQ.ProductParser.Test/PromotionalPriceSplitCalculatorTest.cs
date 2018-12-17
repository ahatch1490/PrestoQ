using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class PromotionalPriceSplitCalculatorTest
    {
        private string line =
            "14963801 Generic Soda 12-pack                                        00000000 00000549 00000000 00001400 00000000 0000004 NNNNYNNNN   12x12oz";

        [Fact]
        public void ShouldReturnSplitPrice()
        {
            var split = new PromotionalPriceSplitCalculator(new NumberFormatter(), new PriceFormatter());
            var price = split.Parse(new ProductSection(line)); 
            Assert.Equal(3.50m,price);
        }
    }
}