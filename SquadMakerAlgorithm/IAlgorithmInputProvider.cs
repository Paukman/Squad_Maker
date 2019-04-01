using System;
using System.Collections.Generic;
using System.Text;

namespace SquadMakerAlgorithm
{
    public interface IAlgorithmInputProvider
    {
        AlgorithmInput ProvideAlgorithmInput(int numberOfSquads, List<SquadPlayer> allPlayers);
    }
}
