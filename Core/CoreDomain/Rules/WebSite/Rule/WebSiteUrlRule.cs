using CoreBussines.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreDomain.Rules.WebSite.Rule
{
    public class WebSiteUrlRule : IBusinessRule
    {
        private readonly string _value;

        public WebSiteUrlRule(string value)
        {
            _value = value;
        }

        public string Message => "El formato de url Incorrecto";

        public bool IsBroken()
        {
            return Uri.IsWellFormedUriString(_value, UriKind.RelativeOrAbsolute);

            //return !Regex.IsMatch(_value, "^(http|http(s)?://)?([w-]+.)+[w-]+[.com|.in|.org]+([?%&=]*)?");
        }
    }
}
