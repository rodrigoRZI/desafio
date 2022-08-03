using System.Linq;
using System.Text.RegularExpressions;

namespace IP.Desafio.Domain.Core.ExtensionMethods
{
    public static class Extensions
    {
        public static bool IsUpper(this string value)
        {
           return value.Any(c => char.IsUpper(c));
        }

        public static bool IsLower(this string value)
        {
            return value.Any(c => char.IsLower(c));
        }

        public static bool IsSpecialCharacter(this string value)
        {
            char[] chars = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+' };
            foreach (var ch in chars)
            {
                if(value.Contains(ch))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsRepeatedCharacter(this string value)
        {
            string str = string.Empty;

            foreach (char ch in value)
            {
                if (str.IndexOf(ch) == -1)
                    str += ch;
                else
                    return true;
            }
            return false;
        }
    }
}