using PulsarFuse.HtmlDocument.Elements;
using Xunit;

namespace TestProject.HtmlDocument
{
    public class MailLinkTests
    {
        [Fact]
        public void SingleElementTest()
        {
            string email = "a@b.c";
            string subject = "subject1";
            string text = "text1";
            MailLink mail = new MailLink(email, subject, text);
            Assert.Equal($"<a href=\"mailto:{email}?subject={subject}\">{text}</a>", mail.ToHtml());
        }

        [Fact]
        public void MultiElementsTest()
        {
            string email = "a@b.c";
            string subject = "subject1";
            string text = "text1";
            MailLink mail = new MailLink(email, subject, text);
            Division div = new Division(mail);

            Assert.Equal($"<div><a href=\"mailto:{email}?subject={subject}\">{text}</a></div>", div.ToHtml());
        }
    }
}
