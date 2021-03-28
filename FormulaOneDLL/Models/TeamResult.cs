using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class TeamResult
    {
        public TeamResult(int trCode, string teamCode, int raceCode, int trTeamPoits)
        {
            this.trCode = trCode;
            this.teamCode = teamCode;
            this.raceCode = raceCode;
            this.trTeamPoits = trTeamPoits;
        }

        public int trCode { get; set; }
        public string teamCode { get; set; }
        public int raceCode { get; set; }
        public int trTeamPoits { get; set; }
    }
}
