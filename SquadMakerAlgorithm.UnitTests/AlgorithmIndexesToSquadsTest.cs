using NUnit.Framework;
using SquadMakerAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMakerAlgorithm.UnitTests
{
    [TestFixture]
    class AlgorithmIndexesToSquadsTest
    {

        private ISquadsAlgorithm _squadsAlgorithm;
        private List<SquadPlayer> _exampleList;
        private List<AlgDynamicSequenceModel> _asdList;

        [SetUp]
        public void ExecuteBeforeEveryTest()
        {
          
            _exampleList = new List<SquadPlayer>()
        {
            new SquadPlayer(){Id = "1", Name="Alex Carney", Checking = 92, Shooting = 98, Skating = 90 },
            new SquadPlayer(){Id = "2", Name="Bob Smith",   Checking = 50, Shooting = 60, Skating = 80 },
            new SquadPlayer(){Id = "3", Name="Roy Talbot",  Checking = 20, Shooting = 85, Skating = 60 },
            new SquadPlayer(){Id = "4", Name="Jill White",  Checking = 60, Shooting = 90, Skating = 70 },
            new SquadPlayer(){Id = "5", Name="Jennifer Wu", Checking = 100, Shooting = 55, Skating = 94 }
        };

      
         
            _asdList = new List<AlgDynamicSequenceModel>()
        {
            new AlgDynamicSequenceModel(){Average = 64, Deviation = 10, ItterationOrder = 0,  Name = "Checking", AvgAprox = -5, SquadSize=2 },
            new AlgDynamicSequenceModel(){Average = 65, Deviation = 10, ItterationOrder = 1,  Name = "Shooting", AvgAprox = -5, SquadSize=2},
            new AlgDynamicSequenceModel(){Average = 78, Deviation = 10, ItterationOrder = 2,  Name = "Skating", AvgAprox = -5, SquadSize=2}
        };

            _squadsAlgorithm = new SquadsAlgorithm();
         }

        [TestCase]
        public void SquadsAlgorithmTest()
        {
            Squad testSquad = _squadsAlgorithm.CombineSingleSquad(2, _exampleList, _asdList);
            Assert.AreEqual(2, testSquad.Players.Count());
        }
    }
}
