using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using SocialScraper.Utils;

namespace SocialScraper.MediaHandling
{
    /// <summary>
    /// 媒体下载器
    /// </summary>
    public class MediaDownloader
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        public static async Task DownloadImageAsync(string imageUrl, string savePath)
        {
            try
            {
                var imageData = await _httpClient.GetByteArrayAsync(imageUrl);
                await File.WriteAllBytesAsync(savePath, imageData);
                Console.WriteLine($"Image saved to: {savePath}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Error downloading image: {ex.Message}");
            }
        }
        /// <summary>
        /// 下载图片并返回路径
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="downloadFolder"></param>
        /// <returns></returns>
        public static async Task<string> DownloadImageAndReturnPathAsync(string imageUrl, string downloadFolder)
        {
            var imageName = Path.GetFileName(imageUrl); // Get image name from URL
            var savePath = Path.Combine(downloadFolder, imageName);
            await DownloadImageAsync(imageUrl, savePath);
            return savePath;
        }
        /// <summary>
        /// 下载视频
        /// </summary>
        /// <param name="videoUrl"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        public static async Task DownloadVideoAsync(string videoUrl, string savePath)
        {
            try
            {
                var videoData = await _httpClient.GetByteArrayAsync(videoUrl);
                await File.WriteAllBytesAsync(savePath, videoData);
                Console.WriteLine($"Video saved to: {savePath}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Error downloading video: {ex.Message}");
            }
        }
        /// <summary>
        /// 下载视频并返回路径
        /// </summary>
        /// <param name="videoUrl"></param>
        /// <param name="downloadFolder"></param>
        /// <returns></returns>
        public static async Task<string> DownloadVideoAndReturnPathAsync(string videoUrl, string downloadFolder)
        {
            var videoName = Path.GetFileName(videoUrl); // Get video name from URL
            var savePath = Path.Combine(downloadFolder, videoName);
            await DownloadVideoAsync(videoUrl, savePath);
            return savePath;
        }
    }
}
