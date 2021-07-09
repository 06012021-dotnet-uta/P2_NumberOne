using System;
using System.Collections.Generic;

#nullable disable

namespace data_models
{
    public partial class AggressionCode
    {
        public AggressionCode()
        {
            Pets = new HashSet<Pet>();
        }

        public int Code { get; set; }
        public string Descriptor { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
