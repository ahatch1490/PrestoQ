using System.ComponentModel;

namespace PrestoQ.ProductParser
{
    public class FlagParser
    {

        
        public  bool GetFlag(string flags, int flagIndex)
        {
            if (string.IsNullOrWhiteSpace(flags))
            {
                return false;
            }

            return flags[flagIndex] == 'Y';
        }
    }
}