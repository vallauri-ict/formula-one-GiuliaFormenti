using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class Race
    {
        public Race(int raceCode, int circuitCode, string raceName, DateTime raceDate, string raceTime, int nLaps, string raceURL)
        {
            this.raceCode = raceCode;
            this.circuitCode = circuitCode;
            this.raceName = raceName;
            this.raceDate = raceDate;
            this.raceTime = raceTime;
            this.nLaps = nLaps;
            this.raceURL = raceURL;
        }

        public int raceCode { get; set; }
        public int circuitCode { get; set; }
        public string raceName { get; set; }
        public DateTime raceDate { get; set; }
        public string raceTime { get; set; }
        public int nLaps { get; set; }
        public string raceURL { get; set; }
    }
}
