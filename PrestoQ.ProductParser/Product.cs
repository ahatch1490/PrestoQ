namespace PrestoQ.ProductParser
{
    public class Product
    {
            public int ProductID { get; set; } = 0; 
            public string Description { get; set; }
            public decimal? RegularSingularPrice { get; set; }
            public string PromotionalSingularPrice { get; set; }
            public string RegularSplitPrice { get; set; }
            public string PromotionalSplitPrice { get; set; }
            public string RegularForX { get; set; }
            public string PromotionalForX { get; set; }
            public bool? IsTaxable { get; set; }
            public bool? IsPerwWight { get; set; }
            public string Flags { get; set; }
            public string ProductSize { get; set; }
    }
}