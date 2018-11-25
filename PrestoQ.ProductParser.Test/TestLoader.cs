using System.IO;

namespace PrestoQ.ProductParser.Test
{
    internal class TestLoader
    {


        public static string  LoadFlatFile(string filename)
        {
            var dir = Path.Combine( $"TestData/{filename}");
            return File.ReadAllText(dir);
        }
    }
}    