using AutomaxWebSite.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace AutomaxWebSite.Models
{
    public class Contact
    {
        
        [UmbracoRequired(errorMessageDictionaryKey: "Name is required")]
        public string Name { get; set; }

        [UmbracoRequired(errorMessageDictionaryKey: "Email Address is required")]
        //[Required(ErrorMessage = "Email Address is required")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        [UmbracoRegularExpression(errorMessageDictionaryKey: "Invalid Email Address", pattern: "([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$")]
        public string Email { get; set; }

       
        [UmbracoRequired(errorMessageDictionaryKey: "Subject is required")]
        public string Subject { get; set; }
        public string Message { get; set; }

        [UmbracoRequired(errorMessageDictionaryKey: "Phone is required")]
        [UmbracoRegularExpression(errorMessageDictionaryKey: "Invalid Phone Number", pattern: "^[0-9]{1,45}$")]
        public string Phone { get; set; }
    }
}