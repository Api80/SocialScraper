using HtmlAgilityPack;
using System;

namespace SocialScraper.Parsing
{
    public abstract class ParserBase
    {
        protected readonly HtmlDocument _document;

        public ParserBase(string htmlContent)
        {
            _document = new HtmlDocument();
            _document.LoadHtml(htmlContent);
        }

        // 抽象方法，具体解析逻辑由子类实现
        public abstract object ParseData();
    }
}
