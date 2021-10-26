namespace Samson.Web.Application.Infrastructure
{
    /// <summary>
    /// Extensions for string type
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks string is null or empty
        /// </summary>
        /// <param name="s">Standard .NET string</param>
        /// <returns>Specifies is null or empty string</returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
    }
}
