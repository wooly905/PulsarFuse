﻿using System.Collections.Generic;
using System.Text;
using PulsarFuse.HtmlDocument.Abstraction;

namespace PulsarFuse.HtmlDocument.Elements
{
    public abstract class BaseElement : IHtmlElementWithChild
    {
        private List<IHtmlElement> _elements;
        private readonly string _htmlElementName;

        protected BaseElement(string id, string name, string htmlElementName, string style = "")
        {
            Id = id;
            Name = name;
            Style = style;
            _htmlElementName = htmlElementName;
        }

        public string Id { get; }
        public string Name { get; }
        public string Style { get; }
        protected IReadOnlyList<IHtmlElement> InnerElements => _elements;

        public void AddElement(IHtmlElement element)
        {
            if (element == null)
            {
                return;
            }

            (_elements ?? (_elements = new List<IHtmlElement>())).Add(element);
        }

        public virtual string ToHtml()
        {
            StringBuilder html = new StringBuilder();
            html.Append('<').Append(_htmlElementName);

            if (!string.IsNullOrWhiteSpace(Id))
            {
                html.Append(" id=\"").Append(Id).Append('\"');
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                html.Append(" name=\"").Append(Name).Append('\"');
            }

            if (!string.IsNullOrWhiteSpace(Style))
            {
                html.Append(" style=\"").Append(Style).Append('\"');
            }

            html.Append(">");

            if (InnerElements != null)
            {
                foreach (IHtmlElement element in InnerElements)
                {
                    html.Append(element.ToHtml());
                }
            }

            html.Append("</").Append(_htmlElementName).Append('>');

            return html.ToString();
        }
    }
}
