namespace MailBuilder.MailComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class Table : MailComponent
    {
        #region Fields

        private readonly int colCnt;

        private readonly List<Row> rows;

        private int rowCnt;

        #endregion

        #region Constructors and Destructors

        public Table(int columns)
        {
            this.rowCnt = 0;
            this.colCnt = columns;

            this.rows = new List<Row>();
        }

        public Table(Row tableHeader)
        {
            this.rowCnt = 1;
            this.colCnt = tableHeader.Length;

            this.rows = new List<Row> { tableHeader };
        }

        #endregion

        #region Public Methods and Operators

        public void AddRow(Row row)
        {
            if (row.Length != this.colCnt)
            {
                throw new Exception("The number of column names must match the number of columns of the table.");
            }

            this.rows.Add(row);
        }

        public override object GetHtml()
        {
            var rowElements = new List<XElement>();
            rowElements.AddRange(this.rows.Select(row => (XElement)row.GetHtml()));
            var table = new XElement("table", rowElements, this.GetStyle());
            return table;
        }

        #endregion
    }
}