namespace MailBuilder.MailComponents
{
    using System.Xml.Linq;

    public class Cell : MailComponent
    {
        #region Constructors and Destructors

        public Cell(MailComponent cellValue)
        {
            this.Content = cellValue;
        }

        public Cell(string cellValue)
        {
            this.Content = new PlainText(cellValue);
        }

        #endregion

        #region Public Properties

        public MailComponent Content { get; set; }

        #endregion

        #region Public Methods and Operators

        public override object GetHtml()
        {
            return new XElement("td", this.Content.GetHtml(), this.GetStyle());
        }

        #endregion
    }
}