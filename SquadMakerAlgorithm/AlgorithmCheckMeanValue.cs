using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SquadMakerAlgorithm
{
    public class AlgorithmCheckMeanValue
    {
        public bool CheckSkillMeanValue(int[] indexedResult, List<SquadPlayer> allPlayers, AlgDynamicSequenceModel asd)
        {
            int average = asd.Average + asd.AvgAprox;
            double sumMin = ((double)average - asd.Deviation) * asd.SquadSize;
            double sumMax = ((double)average + asd.Deviation) * asd.SquadSize;

            int sum = allPlayers.Where((item, index) => indexedResult.Contains(index))
                .Select(p =>
                {
                    if (asd.Name.Equals("Shooting")) return p.Shooting;
                    else if (asd.Name.Equals("Skating")) return p.Skating;
                    else return p.Checking;
                })
                .Sum();

            if (sum >= sumMin && sum <= sumMax)
                return true;
            else
                return false;
        }
    }
}
