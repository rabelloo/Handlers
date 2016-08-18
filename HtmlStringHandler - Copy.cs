using System.Web;

namespace MyApp.Models
{
    /// <summary>
    /// Implements extension methods for IHtmlString handling
    /// </summary>
    public static class HtmlStringHandler
    {
        /// <summary>
        /// Converts a string to a one-line HTML literal
        /// </summary>
        /// <param name="text">String to be converted</param>
        public static IHtmlString ToLiteral(this string text)
        {
            return new HtmlString(
                text
                    .Replace("\r\n", " ")
                    .Replace("\n\r", " ")
                    .Replace('\r', ' ')
                    .Replace('\n', ' ')
                );
        }

        /// <summary>
        /// Converts an IHtmlString to a one-line HTML literal
        /// </summary>
        /// <param name="text">IHtmlString to be converted</param>
        public static IHtmlString ToLiteral(this IHtmlString text)
        {
            return new HtmlString( 
                text
                    .ToString()
                    .Replace("\r\n", " ")
                    .Replace("\n\r", " ")
                    .Replace('\r', ' ')
                    .Replace('\n', ' ')
                );
        }
    }
}