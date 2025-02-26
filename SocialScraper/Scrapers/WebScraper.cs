using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace SocialScraper.Scrapers
{
    // WebScraper.cs
    public abstract class WebScraper
    {
        protected IPage page;

        public WebScraper(IPage page)
        {
            this.page = page;
        }

        // 抽象方法：爬取数据
        public abstract Task<string> ScrapeDataAsync(string url);
    }

}
