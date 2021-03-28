using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL.Models
{
    public class Circuit
    {
        public Circuit(int circuitCode, string circuitName, string circuitCountry, string circuitCity, int circuitMlength, string image)
        {
            this.circuitCode = circuitCode;
            this.circuitName = circuitName;
            this.circuitCountry = circuitCountry;
            this.circuitCity = circuitCity;
            this.circuitMlength = circuitMlength;
            this.image = image;
        }

        public int circuitCode { get; set; }
        public string circuitName { get; set; }
        public string circuitCountry { get; set; }
        public string circuitCity { get; set; }
        public int circuitMlength { get; set; }
        public string image { get; set; }
    }
}
