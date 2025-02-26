using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SocialScraper.Utils;

namespace SocialScraper.AntiScraping
{
    /// <summary>
    /// 代理池类，用于管理和提供代理服务器
    /// </summary>
    public class ProxyPool
    {
        private List<string> _proxyList;
        private Random _random;

        /// <summary>
        /// 初始化 ProxyPool 类的新实例
        /// </summary>
        public ProxyPool()
        {
            _proxyList = new List<string>
            {
                //"http://proxy1.example.com",
                //"http://proxy2.example.com",
                //"http://proxy3.example.com"
                // 可以添加更多代理服务器
            };
            _random = new Random();
        }

        /// <summary>
        /// 获取一个随机的代理服务器地址
        /// </summary>
        /// <returns>随机代理服务器地址</returns>
        public string GetRandomProxy()
        {
            try
            {
                if (_proxyList == null || _proxyList.Count == 0) return string.Empty;
            
                var randomIndex = _random.Next(_proxyList.Count);
                return _proxyList[randomIndex];
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取一个带有代理服务器的 HttpClient 实例
        /// </summary>
        /// <returns>带有代理服务器的 HttpClient 实例</returns>
        public async Task<HttpClient> GetHttpClientWithProxyAsync()
        {
            try
            {
                var clientHandler = new HttpClientHandler
                {
                    Proxy = new System.Net.WebProxy(GetRandomProxy()),
                    UseProxy = true
                };
                return new HttpClient(clientHandler);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
    }
}

