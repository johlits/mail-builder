namespace MailBuilder.MailComponents
{
    public class Paragraph : CustomElement
    {
        #region Constructors and Destructors

        public Paragraph()
            : base("p", null)
        {
        }

        public Paragraph(string content)
            : base("p", new PlainText(content))
        {
        }

        public Paragraph(MailComponent content)
            : base("p", content)
        {
        }

        #endregion
    }
}