namespace MailBuilder.MailComponents
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class Row : MailComponent
    {
        #region Fields

        private readonly Cell[] cells;

        #endregion

        #region Constructors and Destructors

        public Row(params Cell[] values)
        {
            this.cells = values;
        }

        #endregion

        #region Public Properties

        public int Length
        {
            get
            {
                return this.cells.Length;
            }
        }

        #endregion

        #region Public Methods and Operators

        public override object GetHtml()
        {
            List<object> rowElements = this.cells.Select(t => t.GetHtml()).ToList();
            var row = new XElement("tr", rowElements, this.GetStyle());
            return row;
        }

        #endregion
    }
}