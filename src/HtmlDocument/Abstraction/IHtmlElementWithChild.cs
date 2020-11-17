namespace PulsarFuse.HtmlDocument.Abstraction
{
    public interface IHtmlElementWithChild : IHtmlElement
    {
        string Id { get; }

        string Name { get; }

        string Style { get; }

        void AddElement(IHtmlElement element);
    }
}
