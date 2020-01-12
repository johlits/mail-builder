namespace MailBuilder.Tests
{
    using System;
    using System.Collections.Generic;

    using MailBuilder.MailComponents;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        #region Public Methods and Operators

        [Test]
        public void CreateMail()
        {
            var mail = new Mail(
                "Test mail!",
                "sender@example.com",
                new List<string> { "recipient1@example.com", "recipient2@example.com" });

            var paragraphs = new List<MailComponent>
            {
                new Paragraph("This is the first test paragraph. ")
                {
                    Properties =
                        new List<Tuple<string, string>>
                        {
                            new Tuple<string, string>("font-size", "32px"),
                            new Tuple<string, string>("color", "red")
                        }
                },
                new Link("This is the second test paragraph. ", "http://www.google.se/")
            };

            var table =
                new Table(
                    new Row(new Cell("name"), new Cell("age"), new Cell("sex"))
                    {
                        Properties =
                            new List<Tuple<string, string>> { new Tuple<string, string>("font-weight", "bold") }
                    })
                {
                    Properties =
                        new List<Tuple<string, string>>
                        {
                            new Tuple<string, string>("width", "400px"),
                            new Tuple<string, string>("border-spacing", "0px"),
                        }
                };

            table.AddRow(
                new Row(
                    new Cell("Adam"),
                    new Cell("25"),
                    new Cell("male")
                    {
                        Properties = new List<Tuple<string, string>> { new Tuple<string, string>("color", "#0066FF") }
                    }));
            table.AddRow(
                new Row(
                    new Cell(new Link("Berta", "http://www.palplanner.com/")),
                    new Cell("28"),
                    new Cell("female")
                    {
                        Properties = new List<Tuple<string, string>> { new Tuple<string, string>("color", "#FF66FF") }
                    }));
            table.AddRow(
                new Row(
                    new Cell("Caesar"),
                    new Cell("52"),
                    new Cell("male")
                    {
                        Properties = new List<Tuple<string, string>> { new Tuple<string, string>("color", "#0066FF") }
                    }));

            mail.AddMailComponent(paragraphs[0]);
            mail.AddMailComponent(table);
            mail.AddMailComponent(paragraphs[1]);

            var html = mail.GetHtml();

            Assert.IsNotNullOrEmpty(html.ToString());
        }

        #endregion
    }
}
