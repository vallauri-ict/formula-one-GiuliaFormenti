using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class DettaglioDriver
    {
        public DettaglioDriver(int driverCode, string driverFirstname, string driverLastname, string driverCountry, DateTime driverDateOfBirth, string driverPlaceOfBirth, string driverImage, string driverTeam, string driverCountryImage)
        {
            this.driverCode = driverCode;
            this.driverFirstname = driverFirstname;
            this.driverLastname = driverLastname;
            this.driverCountry = driverCountry;
            this.driverDateOfBirth = driverDateOfBirth;
            this.driverPlaceOfBirth = driverPlaceOfBirth;
            this.driverImage = driverImage;
            this.driverTeam = driverTeam;
            this.driverCountryImage = driverCountryImage;
        }

        public int driverCode { get; set; }
        public string driverFirstname { get; set; }
        public string driverLastname { get; set; }
        public string driverCountry { get; set; }
        public DateTime driverDateOfBirth { get; set; }
        public string driverPlaceOfBirth { get; set; }
        public string driverImage { get; set; }
        public string driverTeam { get; set; }
        public string driverCountryImage { get; set; }
    }
}
