namespace MailBuilder.MailComponents
{
    using System.Xml.Linq;

    public class CustomElement : MailComponent
    {
        #region Constructors and Destructors

        public CustomElement(string selector, MailComponent content)
        {
            this.Content = content;
            this.selector = selector;
        }

        #endregion

        #region Public Properties

        public MailComponent Content { get; set; }

        #endregion

        #region Properties

        protected string selector { get; set; }

        #endregion

        #region Public Methods and Operators

        public override object GetHtml()
        {
            return new XElement(this.selector, this.Content.GetHtml(), this.GetStyle());
        }

        #endregion
    }
}