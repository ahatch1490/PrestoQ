using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class RegularPriceTest
    {
        private string line =
            "14963801 Generic Soda 12-pack                                        00000549 00000549 00001300 00000000 00000000 00000000 NNNNYNNNN   12x12oz";

        private string line_empty =
            "14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000000 00000000 NNNNYNNNN   12x12oz";

        [Fact]
        public void ShouldReturnRegularPrice()
        {
            var expected = 5.49m;
            var reg = new RegularPrice(new NumberFormatter(), new PriceFormatter());
            var actual = reg.Parse(new ProductSection(line));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnZeroIfEmpty()
        {
            var expected = 0.00m;
            var reg = new RegularPrice(new NumberFormatter(), new PriceFormatter());
            var actual = reg.Parse(new ProductSection(line_empty));
            Assert.Equal(expected, actual);
        }
    }
}