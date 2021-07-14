using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_models.custom
{
    public  class CurrentLoggedInCustomer
    {
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

    }
}
