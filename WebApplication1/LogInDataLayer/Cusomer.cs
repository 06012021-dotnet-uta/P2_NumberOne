
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LogInDataLayer
{
    public partial class Customer
    {
        [Display(Name = "Customer ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [MaxLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [MaxLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter a username")]
        [MaxLength(20)]
        
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter a password")]
        [MaxLength(20)]
        public string Password { get; set; }

        [Display(Name = "Zip Code")]
        [MaxLength(10)]
        public string ZipCode { get; set; }

        [Display(Name = "Phone No.")]
        [MaxLength(15)]
        public string Phone { get; set; }


        [Display(Name = "Email")]
        [MaxLength(100)]
        public string Email { get; set; }


        [Display(Name = "Home coordinate")]
        [Required(ErrorMessage = "Please enter your Home Coordinate")]
        [MaxLength(100)]
        public string HomeCoordinate { get; set; }

        [Display(Name = "Wandering Radius")]
        [Required(ErrorMessage = "Please enter your Wandering Radius")]
        [MaxLength(100)]
        public string WanderingRadius { get; set; }

    }
}
