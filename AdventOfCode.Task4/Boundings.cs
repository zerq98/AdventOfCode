using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task4
{
    public class Boundings
    {
        public Boundings(string[] split)
        {
            FirstRegionStart = Convert.ToInt32(split[0]);
            FirstRegionEnd= Convert.ToInt32(split[1]);
            SecondRegionStart= Convert.ToInt32(split[2]);
            SecondRegionEnd= Convert.ToInt32(split[3]);
        }

        public int FirstRegionStart { get; set; }
        public int FirstRegionEnd { get; set; }
        public int SecondRegionStart { get; set; }
        public int SecondRegionEnd { get; set;}
    }
}
