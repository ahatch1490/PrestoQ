using System;
using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class SplitPricingTest
    {
//        private string line =
//            "14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz";
//
//        private readonly ProductSection _section; 
//        public SplitPricingTest()
//        {
//            _section = new ProductSection(line);
//        }
        
        [Fact]
        public void ShouldBeAbleToCreateASplitPriceRegular()
        {
            var sp = new SplitPricing();
            var actual = sp.Calculate(13.00m,2.00m);

            Assert.Equal(6.50m, actual); 
        }

    }
}