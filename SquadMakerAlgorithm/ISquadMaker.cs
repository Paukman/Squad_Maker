using System;
using System.Collections.Generic;
using System.Text;

namespace SquadMakerAlgorithm
{
    public interface ISquadMaker
    {
        IEnumerable<Squad> Make(int numberOfSquads);
    }


}
