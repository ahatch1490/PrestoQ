using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class ProductSizeTest
    {
        private string line =
            "14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz";

        [Fact]
        public void ShouldReturnProductSize()
        {
            var size = new ProductSize();
            Assert.Equal("12x12oz",size.Parse(new ProductSection(line)));
        }
    }
}