using System;
using System.Text;

namespace BigRoom.BusinessLayer.Util
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNull(this object value)
        {
            return value == null;
        }

        public static int ToInt32(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static string FromBase64String(this string value)
        {
            return
                Encoding.UTF8.GetString(
                    Convert.FromBase64String(value.Replace('.', '=').Replace('-', '+').Replace('_', '/')));
        }

        public static string ToBase64String(this string value)
        {
            return
                Convert.ToBase64String(Encoding.UTF8.GetBytes(value))
                    .Replace('=', '.')
                    .Replace('+', '-')
                    .Replace('/', '_');
        }
    }
}
