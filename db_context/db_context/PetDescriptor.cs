using System;
using System.Collections.Generic;

#nullable disable

namespace data_models
{
    public partial class PetDescriptor
    {
        public int PetId { get; set; }
        public int ColorationId { get; set; }
        public int? BreedId { get; set; }

        public virtual Breed Breed { get; set; }
        public virtual Coloration Coloration { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
