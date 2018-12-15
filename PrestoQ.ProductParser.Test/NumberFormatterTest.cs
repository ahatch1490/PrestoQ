using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class NumberFormatterTest
    {
        [Fact]
        public void ShouldFormatANumber()
        {
            var actual = new NumberFormatter(0,8,"00002222").Value; 
            Assert.Equal("2222",actual);   
        }
    }
}