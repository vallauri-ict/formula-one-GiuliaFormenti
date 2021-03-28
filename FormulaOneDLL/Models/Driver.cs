using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormulaOneDLL.Models
{
    public class Driver
    {
        public Driver(int driverCode, int driverNumber, string driverFirstname, string driverLastname, /*int driverTeamCode, */string driverNationality, DateTime driverDateOfBirth, string driverPlaceOfBirth, string driverImage, string teamCode)
        {
            this.driverCode = driverCode;
            this.driverNumber = driverNumber;
            this.driverFirstname = driverFirstname;
            this.driverLastname = driverLastname;
            //this.driverTeamCode = driverTeamCode;
            this.driverNationality = driverNationality;
            this.driverDateOfBirth = driverDateOfBirth;
            this.driverPlaceOfBirth = driverPlaceOfBirth;
            this.driverImage = driverImage;
            this.teamCode = teamCode;
        }

        public int driverCode { get; set; }
        public int driverNumber { get; set; }
        public string driverFirstname { get; set; }
        public string driverLastname { get; set; }
        //public int driverTeamCode { get; set; }
        public string driverNationality { get; set; }
        public DateTime driverDateOfBirth { get; set; }
        public string driverPlaceOfBirth { get; set; }
        public string driverImage { get; set; }
        public string teamCode { get; set; }
    }
}
