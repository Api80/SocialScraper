using Microsoft.Playwright;
using Serilog;
using SocialScraper.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialScraper.AntiScraping
{
    /// <summary>
    /// 反爬虫处理
    /// </summary>
    public class AntiScrapingHandler
    {
        private readonly IPage _page;

        public AntiScrapingHandler(IPage page)
        {
            _page = page;
        }

        // 设置浏览器指纹
        public async Task SetBrowserFingerprintAsync()
        {
            try
            {
                var userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36";
                var acceptLanguage = "en-US,en;q=0.9";
                var viewport = new ViewportSize { Width = 2160, Height = 3840 };

                // 设置 User-Agent
                await _page.EvaluateAsync($"navigator.userAgent = '{userAgent}'"); // 使用 EvaluateAsync 设置 User-Agent

                // 设置其他请求头
                await _page.SetExtraHTTPHeadersAsync(new Dictionary<string, string>
            {
                { "Accept-Language", acceptLanguage }
            });

                // 设置浏览器视口大小
                await _page.SetViewportSizeAsync(viewport.Width, viewport.Height);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        // 随机间隔模拟用户行为
        public async Task SimulateUserBehaviorAsync()
        {
            try
            {
                var random = new Random();
                await Task.Delay(random.Next(2000, 5000));  // 随机等待时间
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }
    }
}
