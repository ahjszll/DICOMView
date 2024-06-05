using Masuit.Tools.Security;

namespace CommonLib
{
    public class Secure
    {
        public string MD5(string str) 
        {
            return str.MDString();
        }
    }
}
