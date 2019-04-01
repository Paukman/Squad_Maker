using System;
using System.Collections.Generic;
using System.Text;

namespace SquadMakerAlgorithm
{
    public class PlayerAccessFactory
    {
        public static IPlayerProvider GetFilePlayerDataAccessObj()
        {
            return new FilePlayerProvider();
        }
    }
}
