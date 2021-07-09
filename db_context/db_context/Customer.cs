using System;
using System.Collections.Generic;

#nullable disable

namespace data_models
{
    public partial class Customer
    {
        public Customer()
        {
            Pets = new HashSet<Pet>();
            Posts = new HashSet<Post>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public double? HomeLocationLatitude { get; set; }
        public double? HomeLocationLongitude { get; set; }
        public double? WanderingRadius { get; set; }
        public int? Phone { get; set; }
        public int? ZipCode { get; set; }
        public DateTime AccountCreationDate { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
