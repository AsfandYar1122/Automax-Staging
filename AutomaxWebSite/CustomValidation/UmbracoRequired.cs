using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutomaxWebSite.CustomValidation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class UmbracoRequired : RequiredAttribute, IClientValidatable
    {
        private readonly string _errorMessageDictionaryKey;



        public UmbracoRequired(string errorMessageDictionaryKey)
        {
            _errorMessageDictionaryKey = errorMessageDictionaryKey;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            // var title = UmbracoValidationHelper.GetDictionaryItem(_titleDictionaryKey);
            //var msg = UmbracoValidationHelper.GetDictionaryItem(_errorMessageDictionaryKey);
            ErrorMessage = _errorMessageDictionaryKey;
            if (System.Globalization.CultureInfo.CurrentCulture.Name == "ar")
            {
                if (_errorMessageDictionaryKey== "Name is required")
                {
                    ErrorMessage = "مطلوب اسم";
                }
                else if (_errorMessageDictionaryKey == "Email Address is required")
                {
                    ErrorMessage = "مطلوب عنوان البريد الإلكتروني";
                }
                else if (_errorMessageDictionaryKey == "Subject is required")
                {
                    ErrorMessage = "مطلوب موضوع";
                }
                else if (_errorMessageDictionaryKey == "Phone is required")
                {
                    ErrorMessage = "الهاتف مطلوب";
                }

            }
            var error = FormatErrorMessage(metadata.DisplayName);
            var rule = new ModelClientValidationRequiredRule(error);

            yield return rule;
        }
    }
}