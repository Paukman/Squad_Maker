using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMakerAlgorithm
{
    

    public class AlgorithmSequenceDataProvider : IAlgorithmSequenceDataProvider
    {
        public IEnumerable<AlgDynamicSequenceModel> ProvideSequenceData(AlgorithmInput algorithmInput)
        {
            int iterationOrder = 0;
            foreach (PlayingSkill playingSkill in (PlayingSkill[])Enum.GetValues(typeof(PlayingSkill)))
            {
                string skillType = Enum.GetName(typeof(PlayingSkill), playingSkill);
                AlgDynamicSequenceModel algSeqData = new AlgDynamicSequenceModel()
                {
                    Deviation = algorithmInput.InitialDeviation + iterationOrder, //each subsequent deviation in search algorithm is increased by 1
                    Name = skillType,
                    ItterationOrder = iterationOrder++,
                    //Skill = playingSkill,
                    SquadSize = algorithmInput.SquadSize
                };
                switch (skillType)
                {
                    case "Shooting":
                        algSeqData.Average = algorithmInput.AvgShooting;
                        algSeqData.AvgAprox = algorithmInput.AvgAproxSho;
                        break;
                    case "Skating":
                        algSeqData.Average = algorithmInput.AvgSkating;
                        algSeqData.AvgAprox = algorithmInput.AvgAproxSka;
                        break;
                    case "Checking":
                        algSeqData.Average = algorithmInput.AvgChecking;
                        algSeqData.AvgAprox = algorithmInput.AvgAproxChe;
                        break;
                }

                yield return algSeqData;
            }
        }
    }
}
