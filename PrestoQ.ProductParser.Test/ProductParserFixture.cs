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
    }
}