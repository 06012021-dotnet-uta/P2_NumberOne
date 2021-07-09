using System;
using System.Collections.Generic;

#nullable disable

namespace data_models
{
    public partial class ForumImg
    {
        public int ImgId { get; set; }
        public int ForumId { get; set; }
        public string ImgPath { get; set; }

        public virtual Forum Forum { get; set; }
    }
}
