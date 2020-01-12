namespace MailBuilder
{
    using System.Net;

    public static class HtmlHelper
    {
        #region Public Methods and Operators

        public static string HtmlDecode(string s)
        {
            return WebUtility.HtmlDecode(s);
        }

        public static string HtmlEncode(string s)
        {
            return WebUtility.HtmlEncode(s);
        }

        #endregion
    }
}