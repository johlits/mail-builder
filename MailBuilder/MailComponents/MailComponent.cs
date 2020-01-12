namespace MailBuilder.MailComponents
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Linq;

    public abstract class MailComponent
    {
        #region Fields

        private List<Tuple<string, string>> properties;

        #endregion

        #region Public Properties

        public int Id { get; set; }

        public List<Tuple<string, string>> Properties { get; set; }

        public string Style
        {
            get
            {
                if (this.Properties == null)
                {
                    return null;
                }

                var sb = new StringBuilder("");
                foreach (var prop in this.Properties)
                {
                    sb.AppendFormat("{0}:{1};", prop.Item1, prop.Item2);
                }
                return sb.ToString();
            }
        }

        #endregion

        #region Public Methods and Operators

        public abstract object GetHtml();

        public XAttribute GetStyle()
        {
            return this.Style == null ? null : new XAttribute("style", this.Style);
        }

        #endregion
    }
}