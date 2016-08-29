using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyScott
{
    // Parameters that will be used during simulations
    public class SimulationParameters
    {
        public double DiffA { get; set; }
        public double DiffB { get; set; }
        public double FeedA { get; set; }
        public double KillB { get; set; }
        public double EndFeedA { get; set; }
        public double EndKillB { get; set; }
        public string SaveDirectory { get; set; }
    }
}
