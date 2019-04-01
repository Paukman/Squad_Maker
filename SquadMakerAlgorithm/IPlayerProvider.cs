using System;
using System.Collections.Generic;
using System.Text;

namespace SquadMakerAlgorithm
{
    public interface IPlayerProvider
    {
        IEnumerable<SquadPlayer> ProvidePlayers();
    }


}
