namespace MailBuilder.MailComponents
{
    public class PlainText : MailComponent
    {
        #region Fields

        public string Text;

        #endregion

        #region Constructors and Destructors

        public PlainText(string text)
        {
            this.Text = text;
        }

        #endregion

        #region Public Methods and Operators

        public override object GetHtml()
        {
            return this.Text;
        }

        #endregion
    }
}