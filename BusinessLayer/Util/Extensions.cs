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
    }
}
