using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using SocialScraper.Models;
using SocialScraper.Parsing;

namespace SocialScraper.Scrapers.WeiboScraper
{
    public class WeiboScraper
    {
        private readonly IPage _page;

        public WeiboScraper(IPage page)
        {
            _page = page;
        }

        /// <summary>
        /// 收集帖子数据
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<PostData> CollectPostDataAsync(string postId)
        {
            string url = $"https://weibo.com/{postId}";
            string htmlContent = await ScrapeDataAsync(url);

            // 使用 WeiboParser 解析帖子内容
            var parser = new WeiboParser(htmlContent);
            var postData = parser.ParseData() as PostData;
            return postData;
        }

        /// <summary>
        /// 收集评论数据
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<List<Comment>> CollectCommentsAsync(string postId)
        {
            string url = $"https://weibo.com/{postId}/comments";
            string htmlContent = await ScrapeDataAsync(url);

            // 使用 WeiboParser 解析评论内容
            var parser = new WeiboParser(htmlContent);
            var postData = parser.ParseData() as PostData;
            return postData?.Comments;
        }

        /// <summary>
        /// 收集用户数据
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<PostData>> CollectUserDataAsync(string userId)
        {
            string url = $"https://weibo.com/u/{userId}";
            string htmlContent = await ScrapeDataAsync(url);

            // 使用 WeiboParser 解析用户信息
            var parser = new WeiboParser(htmlContent);
            var postData = parser.ParseData() as List<PostData>;
            return postData;
        }

        /// <summary>
        /// 收集附加数据，例如转发内容等
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public Task<string> CollectAdditionalDataAsync(string postId)
        {
            // 例如，转发内容等
            return Task.FromResult("未实现微博的附加数据");
        }

        public async Task<string> ScrapeDataAsync(string url)
        {
            // 导航到目标页面
            await _page.GotoAsync(url);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await Task.Delay(6000);

            // 模拟滚动加载更多内容
            for (int i = 0; i < 5; i++)  // 增加滚动次数
            {
                // 处理当前视口内的所有展开按钮
                var expandButtons = await _page.QuerySelectorAllAsync(".expand");
                foreach (var button in expandButtons)
                {
                    try
                    {
                        if (button != null)
                        {
                            await button.ScrollIntoViewIfNeededAsync();
                            var boundingBox = await button.BoundingBoxAsync();
                            if (boundingBox != null && boundingBox.Y >= 0 && boundingBox.Y + boundingBox.Height <= _page.ViewportSize.Height)
                            {
                                await button.ClickAsync(new ElementHandleClickOptions { Timeout = 60000 });
                                await Task.Delay(1000);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                await _page.EvaluateAsync("window.scrollBy(0, window.innerHeight);");
                await Task.Delay(5000);  // 增加等待时间，确保数据加载

                // 重新获取页面的 HTML 内容
                string htmlContent = await _page.ContentAsync();
                // 检查是否有新的微博加载
                if (htmlContent.Contains("加载更多"))
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            await Task.Delay(2000);  // 等待更多内容加载

            // 获取页面 HTML 内容
            string finalHtmlContent = await _page.ContentAsync();
            return finalHtmlContent;
        }

    }
}


