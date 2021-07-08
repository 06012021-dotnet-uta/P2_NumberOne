using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer
{
    public partial class PostImage
    {
        public int ImgId { get; set; }
        public int PostId { get; set; }
        public string ImgPath { get; set; }

        public virtual Post Post { get; set; }
    }
}
