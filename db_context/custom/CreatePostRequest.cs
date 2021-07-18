using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_models.custom
{
    public class CreatePostRequest
    {
        public int PosterId { get; set; }
        public int ReplyId { get; set; }
        public int ForumId { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
        public string TextBody { get; set; }
    }
}
