namespace SocialScraper.Models
{
    /// <summary>
    /// 表示一个社交媒体帖子的数据
    /// </summary>
    public class PostData
    {
        /// <summary>
        /// 帖子ID
        /// </summary>
        public string PostId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 帖子内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 帖子中的图片列表
        /// </summary>
        public List<string> Images { get; set; }

        /// <summary>
        /// 帖子中的视频列表
        /// </summary>
        public List<string> Videos { get; set; }

        /// <summary>
        /// 帖子的评论列表
        /// </summary>
        public List<Comment> Comments { get; set; }

        /// <summary>
        /// 帖子的创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// 表示一个评论的数据
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        public string CommentId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 评论的创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}