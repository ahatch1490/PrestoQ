using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class UnitOfMeasureTest
    {
        private readonly string _lb =
            "50133333 Fuji Apples (Organic)                                       00000349 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN        lb";
        private readonly string _each = "40123401 Marlboro Cigarettes                                         00001000 00000549 00000000 00000000 00000000 00000000 YNNNNNNNN          ";

        [Fact]
        public void ShouldReturnEach()
        {
            var uom = new UnitOfMeasure(new FlagParser());
            var unit = uom.Parse(new ProductSection(_each));
            Assert.Equal("Each", unit);  
        }
        
        [Fact]
        public void ShouldReturnPond()
        {
            var uom = new UnitOfMeasure(new FlagParser());
            var unit = uom.Parse(new ProductSection(_lb));
            Assert.Equal("Pound", unit);  
        }
    }
}