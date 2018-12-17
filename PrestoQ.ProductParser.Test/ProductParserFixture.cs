using Xunit;

namespace PrestoQ.ProductParser.Test
{
    public class ProductParserFixture
    {
        [Fact]
        public void ShouldBeAbleToReturnAListOfProducts()
        {
            var flatFile = TestLoader.LoadFlatFile("input-sample.txt");
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);
            
            Assert.NotEmpty(products);
        }
        
        [Fact]
        public void ProductShouldHaveIntegerValue()
        {
            var flatFile = TestLoader.LoadFlatFile("input-sample.txt");
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);
            
            products.ForEach(x => Assert.True(x.ProductId >= 0));
        }
        
        [Fact]
        public void ProductShouldHaveIntegerShouldMatchIntegerValues()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-productIds.txt");     
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);
            
            int[]  expected = {810,80000001};
            Assert.Equal(expected[0], products[0].ProductId);
            Assert.Equal(expected[1], products[1].ProductId);    
        }

        [Fact]
        public void ProductShouldIncludeDescription()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-descriptions.txt");     
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);
            
            products.ForEach(x => Assert.NotNull(x.Description));
        }
        
        [Fact]
        public void ProductShouldBeAbleIncludeLongDescription()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-descriptions.txt");     
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);

            Assert.Equal("1                                                        68", products[0].Description);
        }

        [Fact]
        public void SomeProductsShouldHaveRegularPrice()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-regular-pricing.txt");     
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);
            Assert.Equal("5.67",products[0].RegularSingularPrice);
        }

        [Fact]
        public void HandlesProductsWithCentOnlyValues()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-regular-pricing.txt");     
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);
            Assert.Equal("0.67",products[1].RegularSingularPrice);
        }

        [Fact]
        public void HandlesProductThatHavePromotionalPricing()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-promotional-pricing.txt");     
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);
            Assert.Equal("5.49",products[0].PromotionalSingularPrice);
            Assert.Equal("0.67",products[1].PromotionalSingularPrice);
            Assert.Equal("0.00",products[2].PromotionalSingularPrice);
        }
        
        
        [Fact]
        public void HandlesProductThatHaveRegularSplitPricing()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-split-pricing.txt");     
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);
            Assert.Equal("0.00",products[0].RegularSplitPrice);
            Assert.Equal("6.50",products[1].RegularSplitPrice);
            Assert.Equal("0.9975",products[2].RegularSplitPrice);
        }
        
        [Fact]
        public void HandlesProductThatHavePromotionalSplitPricing()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-split-pricing.txt");     
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);
            Assert.Equal("4.995",products[0].PromotionalSplitPrice);
            Assert.Equal("0.00",products[1].PromotionalSplitPrice);
            Assert.Equal("0.00",products[2].PromotionalSplitPrice);
        }

        [Fact]
        public void HandlesTaxRate()
        {
            var flatFile = TestLoader.LoadFlatFile("input-sample.txt");  
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);
            Assert.Equal("0.00",products[0].TaxRate);
            Assert.Equal("0.7775",products[1].TaxRate);
 
        }

        [Fact]
        public void HandleUnitOfMeasure()
        {
            var flatFile = TestLoader.LoadFlatFile("input-sample.txt");     
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);
            Assert.Equal("Each",products[0].UnitOfMeasure);
            Assert.Equal("Pound",products[3].UnitOfMeasure);
        }

        [Fact]
        public void HandlesProductSize()
        {
            var flatFile = TestLoader.LoadFlatFile("input-sample.txt");     
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);
            Assert.Equal("18oz",products[0].Size);
            Assert.Equal("12x12oz",products[1].Size);
            Assert.Equal("",products[2].Size);
            Assert.Equal("lb",products[3].Size);
        }
        
        [Fact]
        public void ShouldHandleNegativeValues()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-negative-pricing.txt");     
            var parser = new Parser();
            var products = parser.GetProducts(flatFile);
            Assert.Equal("-5.67",products[0].RegularSingularPrice);
            Assert.Equal("-6.50",products[1].RegularSplitPrice);
            Assert.Equal("-5.49",products[2].PromotionalSingularPrice);
            Assert.Equal("-3.49",products[3].RegularSingularPrice);
        }
    }
}