using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_models.custom
{
    public class RegisterColorationRequest
    {
        public int ColorationId { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Pattern { get; set; }
    }
}
