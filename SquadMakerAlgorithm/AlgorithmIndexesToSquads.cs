using System;
using System.Collections.Generic;
using System.Text;

namespace SquadMakerAlgorithm
{
    public class AlgorithmIndexesToSquads
    {
        public Squad ConvertResultIndexesToIds(int[] indexedResult, List<SquadPlayer> allPlayers)
        {
            Squad squad = new Squad() { Players = new List<SquadPlayer>() };

            foreach (int index in indexedResult)
                squad.Players.Add(allPlayers[index]);
            return squad;
        }

    }
}
