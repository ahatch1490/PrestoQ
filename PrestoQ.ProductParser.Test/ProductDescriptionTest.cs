using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class ProductDescriptionTest
    {
        private string line =
            "14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz";

        [Fact]
        public void ShouldReturnDescription()
        {
            var expected = "Generic Soda 12-pack"; 
            var description = new ProductDescription();
            var actual = description.parse(new ProductSection(line)); 
            Assert.Equal(expected,actual);
        }
    }
}