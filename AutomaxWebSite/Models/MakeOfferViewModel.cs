using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutomaxWebSite.Models
{
    public class MakeOfferViewModel
    {
        [Required(ErrorMessage = "Name Required")]
        public string FName{get;set;}
        public string LName { get; set; }
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "City Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Phone Required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Zip Code Required")]
        public string Zip { get; set; }
        public string InternationalPhone { get; set; }

        [Required(ErrorMessage = "Country Required")]
        public string Country { get; set; }
        public string Question { get; set; }

        
        public string Offer { get; set; }
        public bool Financing { get; set; }
        public string MakeOffer { get; set; }
    }
    public class MakeOfferModel
    {

        
        public string FName { get; set; }
        public string LName { get; set; }
        
        public string Address { get; set; }

       
        public string Email { get; set; }

       
        public string City { get; set; }

        
        public string Phone { get; set; }

        
        public string Zip { get; set; }
        public string InternationalPhone { get; set; }

        
        public string Country { get; set; }
        public string Question { get; set; }


        public string Offer { get; set; }
        public bool Financing { get; set; }
        public string MakeOffer { get; set; }
        public string VehicleName { get; set; }
    }
}