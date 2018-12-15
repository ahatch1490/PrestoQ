namespace PrestoQ.ProductParser
{
    public class NumberFormatter
    {
        public string Value { get; }

        public NumberFormatter(int start, int length, string line = "")
        {
            Value = init(start,length, line);
        }

        private string init(int start, int length, string line)
        {
            return string.IsNullOrWhiteSpace(line) ? "" : line.Substring(start, length).TrimStart('0');
        }
    }
}