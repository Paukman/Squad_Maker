using System;
using System.Collections.Generic;
using System.Text;

namespace SquadMakerAlgorithm
{
    public interface ISquadsAlgorithm
    {
        Squad CombineSingleSquad(int squadSize, List<SquadPlayer> idAndSkills, List<AlgDynamicSequenceModel> algSequenceData);
    }
}
