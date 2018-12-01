namespace PrestoQ.ProductParser
{
    public class Product
    {
            public int ProductID { get; set; } = 0; 
            public string Description { get; set; }
            public decimal RegularSingularPrice { get; set; }
            public decimal PromotionalSingularPrice { get; set; }
            public decimal RegularSplitPrice { get; set; }
            public decimal PromotionalSplitPrice { get; set; }
            public decimal TaxRate { get; set; }
            public string UnitOfMeasure { get; set; }
            public string Size { get; set; }
    }
}