using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;
using SocialScraper.Utils;

namespace SocialScraper.TaskScheduling
{
    /// <summary>
    /// 任务调度服务
    /// </summary>
    public class TaskSchedulerService
    {
        private readonly IScheduler _scheduler;

        public TaskSchedulerService()
        {
            // 使用 Quartz 创建一个调度器
            _scheduler = new StdSchedulerFactory().GetScheduler().Result;
        }

        // 启动调度器
        public async Task StartSchedulerAsync()
        {
            try
            {
                await _scheduler.Start();
                Console.WriteLine("Scheduler started.");
                Logger.Information("Scheduler started.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        /// <summary>
        /// 调度任务
        /// </summary>
        /// <param name="taskName">任务名称</param>
        /// <param name="jobDetail">任务的详细信息，包括任务的类型和任务执行时所需的参数</param>
        /// <param name="cronExpression">Cron 表达式，用于定义任务的调度时间</param>
        /// <returns>一个表示异步操作的任务</returns>
        public async Task ScheduleTaskAsync(string taskName, IJobDetail jobDetail, string cronExpression)
        {
            try
            {
                // 创建触发器
                var trigger = TriggerBuilder.Create()
                .WithIdentity(taskName + "Trigger")
                .WithCronSchedule(cronExpression) // Cron 表达式
                .Build();

                // 调度任务
                await _scheduler.ScheduleJob(jobDetail, trigger);
                Console.WriteLine($"任务 {taskName} 已调度，Cron 表达式: {cronExpression}");
                Logger.Information($"任务 {taskName} 已调度，Cron 表达式: {cronExpression}");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        // 停止调度器
        public async Task StopSchedulerAsync()
        {
            try
            {
                await _scheduler.Shutdown();
                Console.WriteLine("Scheduler stopped.");
                Logger.Information("Scheduler stopped.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }
    }
}
