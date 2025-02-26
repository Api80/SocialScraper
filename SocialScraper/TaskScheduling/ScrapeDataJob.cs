using Quartz;
using System;
using System.Threading.Tasks;

namespace SocialScraper.TaskScheduling
{
    /// <summary>
    /// 爬取数据任务
    /// </summary>
    public class ScrapeDataJob : IJob
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
           
            // 任务执行时的逻辑，比如爬取数据
            Console.WriteLine($"Executing ScrapeDataJob at {DateTime.Now}");

            // 模拟数据抓取过程
            await Task.Delay(2000); // 假装在爬取数据
            Console.WriteLine("Data scraped successfully.");
        }
    }
}
