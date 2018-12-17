using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class TaxRateTest
    {
        private readonly string taxable
            = "14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz";

        [Fact]
        public void ShouldReturnTax()
        {
           var expected = 0.7775m; 
           var taxRate = new TaxRate(new FlagParser());
           var actual = taxRate.Parse(new ProductSection(taxable));
           Assert.Equal(expected,actual);
            
        }
    }
}