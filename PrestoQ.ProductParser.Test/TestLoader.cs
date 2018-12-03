using System.IO;

namespace PrestoQ.ProductParser.Test
{
    internal static class TestLoader
    {


        public static string  LoadFlatFile(string filename)
        {
            var dir = Path.Combine( $"TestData/{filename}");
            return File.ReadAllText(dir);
        }
    }
}    