using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class ProductSectionTest
    {
        [Fact]
        public void ShouldBeAbleToGetASectionOfAString()
        {
            var section = new ProductSection("foobarbaz");
            Assert.Equal("bar", section.ValueAt(3,3));
        }
    }
}