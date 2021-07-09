using System;
using System.Collections.Generic;

#nullable disable

namespace data_models
{
    public partial class Category
    {
        public Category()
        {
            Breeds = new HashSet<Breed>();
            Pets = new HashSet<Pet>();
        }

        public int CategoryId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Breed> Breeds { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
