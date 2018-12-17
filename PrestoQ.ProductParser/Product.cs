namespace PrestoQ.ProductParser
{
    public class Product
    {
            public int ProductId { get; set; } 
            public string Description { get; set; }
            public string RegularSingularPrice { get; set; }
            public string PromotionalSingularPrice { get; set; }
            public string RegularSplitPrice { get; set; }
            public string PromotionalSplitPrice { get; set; }
            public string TaxRate { get; set; }
            public string UnitOfMeasure { get; set; }
            public string Size { get; set; }
            public string RawData { get; set; }
    }
}