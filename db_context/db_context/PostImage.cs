using System;
using System.Collections.Generic;

#nullable disable

namespace data_models
{
    public partial class PostImage
    {
        public int ImgId { get; set; }
        public int PostId { get; set; }
        public string ImgPath { get; set; }

        public virtual Post Post { get; set; }
    }
}
