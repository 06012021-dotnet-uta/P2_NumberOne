﻿using System;
using System.Collections.Generic;

#nullable disable

namespace data_models
{
    public partial class Pet
    {
        public Pet()
        {
            Forums = new HashSet<Forum>();
        }

        public int PetId { get; set; }
        public int OwnerId { get; set; }
        public int AggressionCode { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public int Gender { get; set; }
        public int? Age { get; set; }

        public virtual AggressionCode AggressionCodeNavigation { get; set; }
        public virtual Category CategoryNavigation { get; set; }
        public virtual Gender GenderNavigation { get; set; }
        public virtual Customer Owner { get; set; }
        public virtual ICollection<Forum> Forums { get; set; }
    }
}
