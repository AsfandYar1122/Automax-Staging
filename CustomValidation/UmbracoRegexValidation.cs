using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutomaxWebSite.CustomValidation
{
    public class UmbracoRegularExpression : RegularExpressionAttribute, IClientValidatable
    {
        private readonly string _errorMessageDictionaryKey;
       

        public UmbracoRegularExpression(string errorMessageDictionaryKey, string pattern): base(pattern)
        {
            _errorMessageDictionaryKey = errorMessageDictionaryKey;
            
        }
       

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            //ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(_errorMessageDictionaryKey);

           // var title = UmbracoValidationHelper.GetDictionaryItem(_titleDictionaryKey);
           // var msg = UmbracoValidationHelper.GetDictionaryItem(_errorMessageDictionaryKey);
            ErrorMessage = _errorMessageDictionaryKey;
            if (System.Globalization.CultureInfo.CurrentCulture.Name == "ar")
            {
                if (_errorMessageDictionaryKey == "Invalid Email Address")
                {
                    ErrorMessage = "عنوان البريد الإلكتروني غير صالح";
                }
                else if (_errorMessageDictionaryKey == "Invalid Phone Number")
                {
                    ErrorMessage = "رقم الهاتف غير صحيح";
                }
                
            }
                var error= FormatErrorMessage(metadata.DisplayName);
            var rule            = new ModelClientValidationRule();
            rule.ErrorMessage   = error;
            rule.ValidationType = "regex";

            

            rule.ValidationParameters.Add("pattern", this.Pattern);

            yield return rule;
        }
    }
}