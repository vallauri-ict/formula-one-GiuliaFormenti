using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class Result
    {
        public Result(int resultCode, int raceCode, int driverCode, string teamCode, string resultPosition, string resultTime, int resultNlap, int resultPoints, int resultFastestLap, int resultFastestLapTime)
        {
            this.resultCode = resultCode;
            this.raceCode = raceCode;
            this.driverCode = driverCode;
            this.teamCode = teamCode;
            this.resultPosition = resultPosition;
            this.resultTime = resultTime;
            this.resultNlap = resultNlap;
            this.resultPoints = resultPoints;
            this.resultFastestLap = resultFastestLap;
            this.resultFastestLapTime = resultFastestLapTime;
        }

        public int resultCode { get; set; }
        public int raceCode { get; set; }
        public int driverCode { get; set; }
        public string teamCode { get; set; }
        public string resultPosition { get; set; }
        public string resultTime { get; set; }
        public int resultNlap { get; set; }
        public int resultPoints { get; set; }
        public int resultFastestLap { get; set; }
        public int resultFastestLapTime { get; set; }
    }
}
