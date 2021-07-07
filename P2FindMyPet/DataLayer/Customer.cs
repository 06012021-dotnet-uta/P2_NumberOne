using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string HomeCoordinate { get; set; }
        public string Phone { get; set; }
        public string WanderingRadius { get; set; }
    }
}
