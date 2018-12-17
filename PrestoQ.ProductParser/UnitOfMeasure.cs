namespace PrestoQ.ProductParser
{
    public class UnitOfMeasure
    {
        private const int WEIGHT_INDEX = 2; 
        private readonly FlagParser _parser; 
        private const int FLAGS_INDEX = 123;
        private const int LENGTH = 8; 
        
        public UnitOfMeasure(FlagParser parser)
        {
            _parser = parser;
        }

        public string Parse(ProductSection section)
        {
            var measure = "Each";
            if (_parser.GetFlag(section.ValueAt(FLAGS_INDEX,LENGTH),WEIGHT_INDEX))
            {
                measure = "Pound"; 
            }
            return measure; 
        }
    }
}