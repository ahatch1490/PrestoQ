namespace PrestoQ.ProductParser
{
    internal class ProductParser
    {
        private readonly ProductId _productId;
        private readonly ProductDescription _productDescription;
        private readonly RegularPrice _regularPrice;
        private readonly PromotionalPrice _promotionalPrice;
        private readonly RegularPriceSplitCalculator _regularPriceSplitCalculator;
        private readonly PromotionalPriceSplitCalculator _promotionalPriceSplitCalculator;
        private readonly TaxRate _taxRate;
        private readonly ProductSize _productSize;
        private readonly UnitOfMeasure _unitOfMeasure;

        public ProductParser(
            ProductId productId,
            ProductDescription productDescription,
            RegularPrice regularPrice,
            PromotionalPrice promotionalPrice,
            RegularPriceSplitCalculator regularPriceSplitCalculator,
            PromotionalPriceSplitCalculator promotionalPriceSplitCalculator,
            TaxRate taxRate,
            ProductSize productSize,
            UnitOfMeasure unitOfMeasure)
        {
            _productId = productId;
            _productDescription = productDescription;
            _regularPrice = regularPrice;
            _promotionalPrice = promotionalPrice;
            _regularPriceSplitCalculator = regularPriceSplitCalculator;
            _promotionalPriceSplitCalculator = promotionalPriceSplitCalculator;
            _taxRate = taxRate;
            _productSize = productSize;
            _unitOfMeasure = unitOfMeasure;
        }

        public Product Parse(ProductSection section)
        {
            return new Product()
            {
                ProductId = _productId.ToInt(section),
                Description = _productDescription.parse(section),
                RegularSingularPrice = _regularPrice.Parse(section).ToString(),
                PromotionalSingularPrice = _promotionalPrice.Parse(section).ToString(),
                RegularSplitPrice = _regularPriceSplitCalculator.Parse(section).ToString(),
                PromotionalSplitPrice = _promotionalPriceSplitCalculator.Parse(section).ToString(),
                TaxRate = _taxRate.Parse(section).ToString(),
                UnitOfMeasure = _unitOfMeasure.Parse(section),
                Size = _productSize.Parse(section),
                RawData = section.all()

            };
        }
    }
}