using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task11
{
    public class Monkey
    {
        public List<long> StartingItems { get; set; }
        public string Operation { get; set; }
        public int Divider { get; set; }
        public List<int> ThrowToNumbers { get; set; }
        public int InspectTimes { get; set; } = 0;
    }
}
