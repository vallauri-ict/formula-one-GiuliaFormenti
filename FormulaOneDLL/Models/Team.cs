using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class Team
    {
        public Team(string teamCode, string teamFullName, string teamBase, string teamChief, string teamPowerUnit, int teamWorldChampionships, int teamPolePositions, string teamImage)
        {
            this.teamCode = teamCode;
            this.teamFullName = teamFullName;
            this.teamBase = teamBase;
            this.teamChief = teamChief;
            this.teamPowerUnit = teamPowerUnit;
            this.teamWorldChampionships = teamWorldChampionships;
            this.teamPolePositions = teamPolePositions;
            this.teamImage = teamImage;
        }

        public string teamCode { get; set; }
        public string teamFullName { get; set; }
        public string teamBase { get; set; }
        public string teamChief { get; set; }
        public string teamPowerUnit { get; set; }
        public int teamWorldChampionships { get; set; }
        public int teamPolePositions { get; set; }
        public string teamImage { get; set; }
    }
}
