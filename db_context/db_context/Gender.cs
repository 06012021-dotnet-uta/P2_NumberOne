using System;
using System.Collections.Generic;

#nullable disable

namespace data_models
{
    public partial class Gender
    {
        public Gender()
        {
            Pets = new HashSet<Pet>();
        }

        public int Code { get; set; }
        public string Gender1 { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
