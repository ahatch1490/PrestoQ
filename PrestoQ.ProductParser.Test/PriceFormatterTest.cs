using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class PriceFormatterTest
    {
        [Fact]
        public void ShouldParseANumber()
        {
            var formatter = new PriceFormatter();
            var actual = formatter.Parse("2222");
            Assert.Equal(22.22m, actual); 
        }

        [Fact]
        public void ShouldHandleNull()
        {
            var formatter = new PriceFormatter();
            var actual = formatter.Parse(null);
            Assert.Equal(00.00m, actual); 
        }
        
    }
}