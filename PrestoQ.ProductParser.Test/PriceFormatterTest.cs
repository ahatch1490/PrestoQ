using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class PriceFormatterTest
    {
        [Fact]
        public void ShouldParseANumber()
        {
            var formatter = new PriceFormatter("2222");
            var actual = formatter.Value;
            Assert.Equal(22.22m, actual); 
        }

        [Fact]
        public void ShouldHandleNull()
        {
            var formatter = new PriceFormatter(null);
            var actual = formatter.Value;
            Assert.Equal(00.00m, actual); 
        }
        
    }
}