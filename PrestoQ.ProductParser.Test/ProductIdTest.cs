using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class ProductIdTest
    {
            private string line =
            "14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz";
            private string lineSmallId =             
                "00000001 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz";

        
        [Fact]
        public void ShouldReturnProductId()
        {
            var parser = new ProductId(new NumberFormatter()); 
            Assert.Equal(14963801, parser.ToInt(new ProductSection(line)));
        }
        
        [Fact]
        public void ShouldReturnProductIdTrimmingZeros()
        {
            var parser = new ProductId(new NumberFormatter()); 
            Assert.Equal(1, parser.ToInt(new ProductSection(lineSmallId)));
        }
    }
}