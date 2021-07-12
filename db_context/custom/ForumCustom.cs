using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_models.custom
{
    public class ForumCustom
    {
        public int ForumId { get; set; }
        public bool IsClaimed { get; set; }
        public int PetId { get; set; }
        public string ForumName { get; set; }
        public string Description { get; set; }
    }
}
