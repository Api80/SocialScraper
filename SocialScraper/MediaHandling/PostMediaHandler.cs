using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialScraper.MediaHandling
{
    /// <summary>
    /// 帖子媒体处理器
    /// </summary>
    public class PostMediaHandler
    {
        public async Task HandlePostMedia(string imageUrl, string videoUrl, string downloadFolder)
        {
            // 下载图片
            if (!string.IsNullOrEmpty(imageUrl))
            {
                var imagePath = await MediaDownloader.DownloadImageAndReturnPathAsync(imageUrl, downloadFolder);
                Console.WriteLine($"Image saved to: {imagePath}");
            }

            // 下载视频
            if (!string.IsNullOrEmpty(videoUrl))
            {
                var videoPath = await MediaDownloader.DownloadVideoAndReturnPathAsync(videoUrl, downloadFolder);
                Console.WriteLine($"Video saved to: {videoPath}");
            }
        }
    }
}
