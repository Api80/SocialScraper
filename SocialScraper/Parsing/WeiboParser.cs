using HtmlAgilityPack;
using SocialScraper.Models;
using SocialScraper.Parsing;
using SocialScraper.Utils;
using System;
using System.Collections.Generic;

public class WeiboParser : ParserBase
{
    public WeiboParser(string htmlContent) : base(htmlContent) { }

    public override object ParseData()
    {
        try
        {
            var postDataList = new List<PostData>();

            // 定位到每一条微博
            var weiboNodes = _document.DocumentNode.SelectNodes("//div[contains(@class, 'vue-recycle-scroller__item-view')]");

            if (weiboNodes != null)
            {
                foreach (var node in weiboNodes)
                {
                    var postData = new PostData();

                    // 解析微博ID（从URL中提取）
                    var postIdNode = node.SelectSingleNode(".//a[contains(@href, 'weibo.com')]");
                    if (postIdNode != null)
                    {
                        var postIdUrl = postIdNode.GetAttributeValue("href", "");
                        var postId = postIdUrl.Split('/')[^1];  // 获取URL中的最后部分作为微博ID
                        postData.PostId = postId;
                    }


                    var userNameNode = node.SelectSingleNode(".//a[contains(@class, 'head_name_24eEB')]");
                    if (userNameNode != null)
                    {
                        postData.UserName = userNameNode.InnerText.Trim();
                        postData.UserId = userNameNode.GetAttributeValue("usercard", "");
                    }

                    // 解析微博内容
                    var contentNode = node.SelectSingleNode(".//div[contains(@class, 'detail_text_1U10O')]");
                    if (contentNode != null)
                    {
                        postData.Content = contentNode.InnerText.Trim();
                    }

                    // 解析发布时间
                    var timeNode = node.SelectSingleNode(".//a[@class='head-info_time_6sFQg']");
                    if (timeNode != null)
                    {
                        string timeString = timeNode.GetAttributeValue("title", "");
                        if (DateTime.TryParse(timeString, out DateTime parsedDateTime))
                        {
                            postData.CreatedAt = parsedDateTime;
                        }
                    }

                    // 解析帖子中的图片
                    var imagesNodes = node.SelectNodes(".//img[contains(@class, 'post_image')]");
                    postData.Images = new List<string>();
                    if (imagesNodes != null)
                    {
                        foreach (var imageNode in imagesNodes)
                        {
                            postData.Images.Add(imageNode.GetAttributeValue("src", ""));
                        }
                    }

                    var videoNode = node.SelectSingleNode(".//a[contains(@href, 'video.weibo.com/show')]");
                    if (videoNode != null)
                    {
                        string videoUrl = videoNode.GetAttributeValue("href", "").Trim();
                        postData.Videos = new List<string> { videoUrl };
                    }
                    // 将每一条微博数据添加到列表中
                    postDataList.Add(postData);
                }
            }

            return postDataList;
        }
        catch (Exception ex)
        {
            Logger.Error($"Error parsing Weibo data: {ex.Message}");
            return null;
        }
    }
}
