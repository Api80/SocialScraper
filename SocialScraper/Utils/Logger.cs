using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Sinks.File; // 添加此行

namespace SocialScraper.Utils
{
    public static class Logger
    {
        static Logger()
        {
            // 配置日志记录器
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)  // 输出到文件，每天一个新文件
                .CreateLogger();
        }

        public static void Information(string message)
        {
            Log.Information(message);
        }

        public static void Warning(string message)
        {
            Log.Warning(message);
        }

        public static void Error(string message)
        {
            Log.Error(message);
        }

        public static void Fatal(string message)
        {
            Log.Fatal(message);
        }

        public static void Close()
        {
            Log.CloseAndFlush();
        }
    }
}
