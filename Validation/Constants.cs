using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validation
{
    internal class Constants
    {
        public const string RegName = @"^[A-Za-z]+(?:\s+[A-Za-z]+)*$";
        public const string RegPostalCode = @"^[A-Z][0-9][A-Z][- ]?[0-9][A-Z][0-9]$";
        public const string RegProvince = @"^(AB|BC|MB|NB|NL|NT|NS|NU|ON|PE|QC|SK|YT)$";
        public const string RegPhone = @"^[(]?(\d{3})[)]?-?(\d{3})-?(\d{4})$";
        public const string RegEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
    }
}
