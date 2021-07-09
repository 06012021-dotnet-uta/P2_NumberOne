using System;
using System.Collections.Generic;

#nullable disable

namespace data_models
{
    public partial class Post
    {
        public Post()
        {
            InverseReply = new HashSet<Post>();
            PostImages = new HashSet<PostImage>();
        }

        public int PostId { get; set; }
        public int PosterId { get; set; }
        public int ReplyId { get; set; }
        public int ForumId { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
        public string TextBody { get; set; }
        public DateTime PostTime { get; set; }

        public virtual Forum Forum { get; set; }
        public virtual Customer Poster { get; set; }
        public virtual Post Reply { get; set; }
        public virtual ICollection<Post> InverseReply { get; set; }
        public virtual ICollection<PostImage> PostImages { get; set; }
    }
}
