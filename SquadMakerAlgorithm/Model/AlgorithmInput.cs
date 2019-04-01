using System;
using System.Collections.Generic;
using System.Text;

namespace SquadMakerAlgorithm
{
    public class AlgorithmInput
    {
        public int NumberOfSquads { get; set; }
        public int SquadSize { get; set; }
        public int NumberOfPlayers { get; set; }
        public int BenchSize { get; set; }

        public int AvgSkating { get; set; }
        public int AvgShooting { get; set; }
        public int AvgChecking { get; set; }

        public int AvgAproxSka { get; set; }
        public int AvgAproxSho { get; set; }
        public int AvgAproxChe { get; set; }

        public double InitialDeviation { get; set; }

        public List<AlgDynamicSequenceModel> SequenceData { get; set; }
        public List<SquadPlayer> AllPlayers { get; set; }
    }
}
