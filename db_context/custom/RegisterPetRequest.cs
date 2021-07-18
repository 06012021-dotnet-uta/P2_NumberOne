using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_models.custom
{
    public class RegisterPetRequest
    {
        //public int PetId { get; set; }
        public int OwnerId { get; set; }
        public int AggressionCode { get; set; }
        public int Category { get; set; }
        public int Gender { get; set; }
        public int? Age { get; set; }
        public string Name { get; set; }

    }
}
