using HtmlAgilityPack;
using SocialScraper.Models;
using SocialScraper.Utils;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SocialScraper.Parsing
{
    /// <summary>
    /// 抖音解析器
    /// </summary>
    public class DouyinParser : ParserBase
    {
        public DouyinParser(string htmlContent) : base(htmlContent) { }

        public override object ParseData()
        {
            //try
            //{
            //    var postData = new PostData();

            //    // 解析帖子ID
            //    var postIdNode = _document.DocumentNode.SelectSingleNode("//div[@class='video_id']");
            //    if (postIdNode != null)
            //    {
            //        postData.PostId = postIdNode.InnerText.Trim();
            //    }

            //    // 解析用户ID（通过 usercard 属性）
            //    var userIdNode = node.SelectSingleNode(".//a[contains(@usercard, '')]");
            //    if (userIdNode != null)
            //    {
            //        var userId = userIdNode.GetAttributeValue("usercard", "");
            //        if (!string.IsNullOrEmpty(userId))
            //        {
            //            postData.UserId = userId.Split('=')[1];  // 提取usercard中的ID
            //        }
            //    }

            //    var userNameNode = _document.DocumentNode.SelectSingleNode("//a[@class='user_id']");
            //    if (userNameNode != null)
            //    {
            //        postData.UserName = userNameNode.InnerText.Trim();
            //    }
            //    // 解析帖子内容（如视频标题）
            //    var contentNode = _document.DocumentNode.SelectSingleNode("//div[@class='video_title']");
            //    if (contentNode != null)
            //    {
            //        postData.Content = contentNode.InnerText.Trim();
            //    }

            //    // 解析视频链接
            //    var videoNode = _document.DocumentNode.SelectSingleNode("//video[@class='video_player']");
            //    if (videoNode != null)
            //    {
            //        postData.Videos = new List<string> { videoNode.GetAttributeValue("src", "") };
            //    }

            //    // 解析评论
            //    var commentsNodes = _document.DocumentNode.SelectNodes("//div[@class='comment']");
            //    postData.Comments = new List<Comment>();
            //    if (commentsNodes != null)
            //    {
            //        foreach (var commentNode in commentsNodes)
            //        {
            //            var comment = new Comment
            //            {
            //                CommentId = commentNode.GetAttributeValue("data-id", ""),
            //                UserId = commentNode.SelectSingleNode(".//a[@class='user_id']").InnerText.Trim(),
            //                Content = commentNode.SelectSingleNode(".//p[@class='comment_content']").InnerText.Trim(),
            //                CreatedAt = DateTime.Now
            //            };
            //            postData.Comments.Add(comment);
            //        }
            //    }

            //    postData.CreatedAt = DateTime.Now;
            //    return postData;
            //}
            //catch (Exception ex)
            //{
            //    Logger.Error($"Error parsing Douyin data: {ex.Message}");
                return null;
            //}
        }

    }
}
