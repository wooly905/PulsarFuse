using PulsarFuse.HtmlDocument.Abstraction;

namespace PulsarFuse.HtmlDocument.Elements
{
    public class LineBreak : IHtmlElement
    {
        public string ToHtml()
        {
            return $"<{ElementNames.LinkBreak}>";
        }
    }
}
