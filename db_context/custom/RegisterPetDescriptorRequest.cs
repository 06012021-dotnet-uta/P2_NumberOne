using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_models.custom
{
     public class RegisterPetDescriptorRequest
    {
        public int PetId { get; set; }
        public int ColorationId { get; set; }
        public int? BreedId { get; set; }
    }
}
