using System;

namespace PrestoQ.ProductParser
{
    public class ProductId
    {
        private readonly NumberFormatter _formatter;
        private const int START_INDEX = 0;
        private const int LENGTH = 8;


        public ProductId(NumberFormatter formatter)
        {
            _formatter = formatter;
        }

        public int ToInt(ProductSection section)
        {
            var value = _formatter.parse(section.ValueAt(START_INDEX, LENGTH));
            return Convert.ToInt32(value);
        }
    }
}