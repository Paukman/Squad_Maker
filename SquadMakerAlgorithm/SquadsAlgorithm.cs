using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMakerAlgorithm
{
    public class SquadsAlgorithm : ISquadsAlgorithm
    {
        private readonly AlgorithmIndexesToSquads _algorithmIndexesToSquads;
        private readonly AlgorithmCheckMeanValue _algorithmCheckMeanValue;

        public SquadsAlgorithm() {

            _algorithmIndexesToSquads = new AlgorithmIndexesToSquads();
            _algorithmCheckMeanValue = new AlgorithmCheckMeanValue();
        }
        
        public Squad CombineSingleSquad(int squadSize, List<SquadPlayer> idAndSkills, List<AlgDynamicSequenceModel> algSequenceData)
        {
            int[] indexedResult = new int[squadSize];
            int noPlayers = idAndSkills.Count();

            Stack<int> stack = new Stack<int>(squadSize);
            stack.Push(0);
            
            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();
                while (value < noPlayers)
                {
                    indexedResult[index++] = value++;
                    stack.Push(value);
                    if (index != squadSize) continue;

                    int seqIndex = 0;
                    bool pass = true;
                    while (pass && (seqIndex < algSequenceData.Count()))
                    {
                        AlgDynamicSequenceModel asd = algSequenceData
                            .FirstOrDefault(p => p.ItterationOrder.Equals(seqIndex));
                        if (!_algorithmCheckMeanValue.CheckSkillMeanValue(indexedResult, idAndSkills, asd))
                        {
                            pass = false;
                            break;
                        }
                        seqIndex++;
                    }

                    if (pass)
                    {
                        Squad squad = new Squad();
                        squad = _algorithmIndexesToSquads.ConvertResultIndexesToIds(indexedResult, idAndSkills);
                        return squad;
                    }
                    break;
                }
            }
            return null;
        }

    }

}
