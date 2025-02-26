// See https://aka.ms/new-console-template for more information
using Quartz;
using SocialScraper.AntiScraping;
using SocialScraper.Scrapers.WeiboScraper;
using SocialScraper.Services;
using SocialScraper.TaskScheduling;

Console.WriteLine("Hello, World!");
var page = await BrowserService.InitializeBrowserAsync();
// 使用微博爬虫
var weiboScraper = new WeiboScraper(page);

string url = "2656274875";
var htmlContent = await weiboScraper.CollectUserDataAsync(url);

//打印抓取的 HTML 内容
Console.WriteLine(htmlContent);

//{
//    // 创建调度服务实例
//    var taskScheduler = new TaskSchedulerService();

//    // 启动调度器
//    await taskScheduler.StartSchedulerAsync();

//    // 创建定时任务 ScrapeDataJob
//    var jobDetail = JobBuilder.Create<ScrapeDataJob>()
//        .WithIdentity("scrapeDataJob") // 设置任务的标识
//        .Build();

//    // 设置定时任务的 Cron 表达式，这里设定为每天中午12点执行
//    string cronExpression = "0 0/1 * * * ?";

//    // 调度任务
//    await taskScheduler.ScheduleTaskAsync("ScrapeDataJob", jobDetail, cronExpression);

//    // 等待一些时间后停止调度器
//    await Task.Delay(10000);
//    await taskScheduler.StopSchedulerAsync();
//}