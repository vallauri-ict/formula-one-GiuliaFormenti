using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class Country
    {
        public Country(string countryCode, string countryName)
        {
            this.countryCode = countryCode;
            this.countryName = countryName;
        }

        public string countryCode { get; set; }
        public string countryName { get; set; }
    }
}
