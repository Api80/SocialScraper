using Microsoft.Playwright;
using SocialScraper.AntiScraping;
using System.Threading.Tasks;
using SocialScraper.Utils;

namespace SocialScraper.Services
{
    /// <summary>
    /// 浏览器服务类，用于初始化浏览器实例
    /// </summary>
    public class BrowserService
    {
        public static async Task<IPage> InitializeBrowserAsync()
        {
            try
            {

                // 初始化 ProxyPool 并获取一个随机代理
                var proxyPool = new ProxyPool();
                var proxy = proxyPool.GetRandomProxy();

                // 初始化 Playwright
                var playwright = await Playwright.CreateAsync();
                var launchOptions = new BrowserTypeLaunchOptions
                {
                    Headless = true
                };
                // 如果有可用的代理，则设置代理
                if (!string.IsNullOrEmpty(proxy))
                {
                    launchOptions.Proxy = new Proxy
                    {
                        Server = proxy
                    };
                }
                var browser = await playwright.Chromium.LaunchAsync(launchOptions);
                var page = await browser.NewPageAsync();

                // 模拟鼠标和键盘行为（可以自定义更多的行为）
                await page.Mouse.MoveAsync(100, 100); // 模拟鼠标移动
                //await page.Mouse.ClickAsync(100, 100); // 模拟点击

                // 模拟滚动页面
                await page.Mouse.WheelAsync(0, 1000);

                // 初始化 AntiScrapingHandler 进行反爬虫设置
                var antiScrapingHandler = new AntiScrapingHandler(page);
                await antiScrapingHandler.SetBrowserFingerprintAsync();
                await antiScrapingHandler.SimulateUserBehaviorAsync();

                // 返回初始化好的页面实例
                return page;
            }
            catch (Exception ex)
            {
                // 处理异常
                Logger.Error(ex.Message);
                return null;
            }
        }
    }
}
