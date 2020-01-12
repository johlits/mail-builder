namespace MailBuilder
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;
    using System.Xml.Linq;

    using MailBuilder.MailComponents;

    public class Mail
    {
        #region Fields

        private readonly List<MailComponent> mailComponents;

        private int componentId;

        private IList<string> recipients;

        private string sender;

        private string subject;

        #endregion

        #region Constructors and Destructors

        public Mail(string subject, string sender, List<string> recipients)
        {
            this.mailComponents = new List<MailComponent>();
            this.subject = subject;
            this.sender = sender;
            this.recipients = recipients;
            this.componentId = 0;
        }

        #endregion

        #region Public Methods and Operators

        public void AddMailComponent(MailComponent mailComponent)
        {
            mailComponent.Id = this.componentId++;
            this.mailComponents.Add(mailComponent);
        }

        public XDocument GetHtml()
        {
            var doc = new XDocument(new XElement("div", this.mailComponents.Select(x => x.GetHtml())));
            return doc;
        }

        public void Send(int port, bool useDefaultCredentials, string mailHost)
        {
            foreach (var recipient in recipients)
            {
                var mail = new MailMessage(sender, recipient) { IsBodyHtml = true };
                var client = new SmtpClient
                {
                    Port = port,
                    UseDefaultCredentials = useDefaultCredentials,
                    Host = mailHost
                };
                mail.Subject = this.subject;
                mail.Body = GetHtml().ToString();
                client.Send(mail);
            }
        }

        #endregion
    }
}