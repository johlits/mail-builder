namespace MailBuilder.MailComponents
{
    using System.Xml.Linq;

    public class Link : MailComponent
    {
        #region Constructors and Destructors

        public Link(MailComponent content, string href)
        {
            this.Content = content;
            this.Href = href;
        }

        public Link(string content, string href)
        {
            this.Content = new PlainText(content);
            this.Href = href;
        }

        #endregion

        #region Properties

        private MailComponent Content { get; set; }

        private string Href { get; set; }

        #endregion

        #region Public Methods and Operators

        public override object GetHtml()
        {
            return new XElement("a", this.Content.GetHtml(), new XAttribute("href", this.Href), this.GetStyle());
        }

        #endregion
    }
}