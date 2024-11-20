using NewBase.Core.Helpers.Security;
using System.Text.RegularExpressions;

namespace NewBase.Core.ExtensionsMethods
{
    public static partial class ExtensionMethods
    {
        public static string ToUniformedPath(this string path)
        {
            return path.Replace("\\", "/");
        }

        public static string SplitPascal(this string str)
        {
            Regex Reg = new Regex("([a-z,0-9](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", RegexOptions.Compiled);
            return Reg.Replace(str, "$1 ");
        }

        public static string Encrypt(this string text)
        {
            return CryptographyHelper.Encrypt(text);
        }

        public static string Decrypt(this string cipherText)
        {
            return CryptographyHelper.Decrypt(cipherText);
        }

        public static long DecryptToNumber(this string cipherText)
        {
            return long.Parse(CryptographyHelper.Decrypt(cipherText));
        }
    }
}
