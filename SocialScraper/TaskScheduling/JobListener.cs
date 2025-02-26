using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz.Listener;
using Quartz;
using SocialScraper.Utils;
namespace SocialScraper.TaskScheduling
{

    /// <summary>
    /// 任务监听器，用于监控任务执行情况
    /// </summary>
    public class JobListener : JobListenerSupport
    {
        public override string Name => "GlobalJobListener";

        public override Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                Console.WriteLine($"任务 {context.JobDetail.Key} 即将执行。");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in JobToBeExecuted: {ex.Message}");
                Logger.Information($"Error in JobToBeExecuted: {ex.Message}");
                return Task.CompletedTask;
            }
        }

        public override Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default)
        {
            try
            {
                if (jobException != null)
                {
                    Console.WriteLine($"Job {context.JobDetail.Key} failed with exception: {jobException.Message}");
                    Logger.Information($"Job {context.JobDetail.Key} failed with exception: {jobException.Message}");
                    // 重试机制
                    context.Scheduler.RescheduleJob(context.Trigger.Key, context.Trigger);
                }
                else
                {
                    Console.WriteLine($"Job {context.JobDetail.Key} executed successfully.");
                    Logger.Information($"Job {context.JobDetail.Key} executed successfully.");
                }
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in JobWasExecuted: {ex.Message}");
                Logger.Information($"Error in JobWasExecuted: {ex.Message}");
           
                return Task.CompletedTask;
            }
        }
    }
}
