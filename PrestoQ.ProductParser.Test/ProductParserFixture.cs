using System;
using Xunit;
using PrestoQ.ProductParser;
using Xunit.Sdk;

namespace PrestoQ.ProductParser.Test
{
    public class ProductParserFixture
    {
        [Fact]
        public void ShouldBeAbleToReturnAListOfProducts()
        {
            var flatFile = TestLoader.LoadFlatFile("input-sample.txt");
            var Products = Parser.GetProducts(flatFile);
            
            Assert.NotEmpty(Products);
        }
        
        [Fact]
        public void ProductShouldHaveIntegerValue()
        {
            var flatFile = TestLoader.LoadFlatFile("input-sample.txt");
            var Products = Parser.GetProducts(flatFile);
            
            Products.ForEach(x => Assert.True(x.ProductID >= 0));
        }
        
        [Fact]
        public void ProductShouldHaveIntegerShouldMatchIntegerValues()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-productIds.txt");     
            var Products = Parser.GetProducts(flatFile);
            
            int[]  expected = {810,80000001};
            Assert.Equal(expected[0], Products[0].ProductID);
            Assert.Equal(expected[1], Products[1].ProductID);    
        }

        [Fact]
        public void ProductShouldIncludeDescription()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-descriptions.txt");     
            var Products = Parser.GetProducts(flatFile);
            
            Products.ForEach(x => Assert.NotNull(x.Description));
        }
        
        [Fact]
        public void ProductShouldBeAbleIncludeLongDescription()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-descriptions.txt");     
            var Products = Parser.GetProducts(flatFile);

            Assert.Equal("1                                                        68", Products[0].Description);
        }

        [Fact]
        public void SomeProductsShouldHaveRegularPrice()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-regular-pricing.txt");     
            var Products = Parser.GetProducts(flatFile);
            Assert.Equal(5.67m,Products[0].RegularSingularPrice);
        }

        [Fact]
        public void HandlesProductsWithCentOnlyValues()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-regular-pricing.txt");     
            var Products = Parser.GetProducts(flatFile);
            Assert.Equal(0.67m,Products[1].RegularSingularPrice);
        }

        [Fact]
        public void HandlesProductThatHavePromotionalPricing()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-promotional-pricing.txt");     
            var Products = Parser.GetProducts(flatFile);
            Assert.Equal(5.49m,Products[0].PromotionalSingularPrice);
            Assert.Equal(0.67m,Products[1].PromotionalSingularPrice);
            Assert.Equal(0.00m,Products[2].PromotionalSingularPrice);
        }
        
        
        [Fact]
        public void HandlesProductThatHaveRegularSplitPricing()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-split-pricing.txt");     
            var Products = Parser.GetProducts(flatFile);
            Assert.Equal(0.00m,Products[0].RegularSplitPrice);
            Assert.Equal(6.50m,Products[1].RegularSplitPrice);
            Assert.Equal(0.9975m,Products[2].RegularSplitPrice);
        }
        
        [Fact]
        public void HandlesProductThatHavePromotionalSplitPricing()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-split-pricing.txt");     
            var Products = Parser.GetProducts(flatFile);
            Assert.Equal(4.995m,Products[0].PromotionalSplitPrice);
            Assert.Equal(0.00m,Products[1].PromotionalSplitPrice);
            Assert.Equal(0.00m,Products[2].PromotionalSplitPrice);
        }

        [Fact]
        public void HandlesTaxRate()
        {
            var flatFile = TestLoader.LoadFlatFile("input-sample.txt");     
            var Products = Parser.GetProducts(flatFile);
            Assert.Equal(0.00m,Products[0].TaxRate);
            Assert.Equal(0.7775m,Products[1].TaxRate);
 
        }

        [Fact]
        public void HandleUnitOfMeasure()
        {
            var flatFile = TestLoader.LoadFlatFile("input-sample.txt");     
            var Products = Parser.GetProducts(flatFile);
            Assert.Equal("Each",Products[0].UnitOfMeasure);
            Assert.Equal("Pound",Products[3].UnitOfMeasure);
        }

        [Fact]
        public void HandlesProductSize()
        {
            var flatFile = TestLoader.LoadFlatFile("input-sample.txt");     
            var Products = Parser.GetProducts(flatFile);
            Assert.Equal("18oz",Products[0].Size);
            Assert.Equal("12x12oz",Products[1].Size);
            Assert.Equal("",Products[2].Size);
            Assert.Equal("lb",Products[3].Size);
        }
        
        [Fact]
        public void ShouldHandleNegativeValues()
        {
            var flatFile = TestLoader.LoadFlatFile("input-test-nagative-pricing.txt");     
            var Products = Parser.GetProducts(flatFile);
            Assert.Equal(-5.67m,Products[0].RegularSingularPrice);
            Assert.Equal(-6.50m,Products[1].RegularSplitPrice);
            Assert.Equal(-5.49m,Products[2].PromotionalSingularPrice);
            Assert.Equal(-3.49m,Products[3].RegularSingularPrice);
        }
    }
}