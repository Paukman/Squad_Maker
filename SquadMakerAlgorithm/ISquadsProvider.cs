using System;
using System.Collections.Generic;
using System.Text;

namespace SquadMakerAlgorithm
{
    public interface ISquadsProvider
    {
        IEnumerable<Squad> ProvideSquads(AlgorithmInput algorithmInput);
    }
}
