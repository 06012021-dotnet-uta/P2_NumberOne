using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer
{
    public partial class Breed
    {
        public int BreedId { get; set; }
        public int CategoryId { get; set; }
        public string Breed1 { get; set; }

        public virtual Category Category { get; set; }
    }
}
