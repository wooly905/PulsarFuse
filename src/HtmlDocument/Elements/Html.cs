using PulsarFuse.HtmlDocument.Abstraction;

namespace PulsarFuse.HtmlDocument.Elements
{
    public class Html : BaseElement
    {

        public Html()
            : base("", "", ElementNames.Html)
        {
        }

        public Html(IHtmlElement element)
            : base("", "", ElementNames.Html)
        {
            AddElement(element);
        }
    }
}
