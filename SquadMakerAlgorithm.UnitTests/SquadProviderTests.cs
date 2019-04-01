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
    class SquadProviderTests
    {
        private ISquadsProvider _squadsProvider;
        private AlgorithmInput testAlgorithmInput;
        private List<SquadPlayer> testPlayerList;
        private List<AlgDynamicSequenceModel> testAsdList;

        [SetUp]
        public void ExecuteBeforeEveryTest()
        {
            testAlgorithmInput = new AlgorithmInput()
            {
                SquadSize = 2,
                AvgChecking = 64,
                AvgShooting = 65,
                AvgSkating = 78,
                BenchSize = 1,
                InitialDeviation = 5,
                NumberOfPlayers = 5,
                NumberOfSquads = 2,
                AvgAproxChe = -5,
                AvgAproxSho = -5,
                AvgAproxSka = -5
            };

            testPlayerList = new List<SquadPlayer>()
        {
            new SquadPlayer(){Id = "1", Name="Alex Carney", Checking = 92, Shooting = 98, Skating = 90 },
            new SquadPlayer(){Id = "2", Name="Bob Smith",   Checking = 50, Shooting = 60, Skating = 80 },
            new SquadPlayer(){Id = "3", Name="Roy Talbot",  Checking = 20, Shooting = 85, Skating = 60 },
            new SquadPlayer(){Id = "4", Name="Jill White",  Checking = 60, Shooting = 90, Skating = 70 },
            new SquadPlayer(){Id = "5", Name="Jennifer Wu", Checking = 100, Shooting = 55, Skating = 94 }
        };

            testAsdList = new List<AlgDynamicSequenceModel>()
        {
            new AlgDynamicSequenceModel(){Average = 64, Deviation = 10, ItterationOrder = 0,  Name = "Checking",  AvgAprox = -5, SquadSize =2},
            new AlgDynamicSequenceModel(){Average = 65, Deviation = 10, ItterationOrder = 1,  Name = "Shooting",  AvgAprox = -5, SquadSize = 2},
            new AlgDynamicSequenceModel(){Average = 78, Deviation = 10, ItterationOrder = 2,  Name = "Skating",  AvgAprox = -5, SquadSize = 2}
        };

            _squadsProvider = new SquadsProvider();
            testAlgorithmInput.SequenceData = testAsdList;
            testAlgorithmInput.AllPlayers = testPlayerList;
        }

        [TestCase]
        public void ProvideSquadsNoOfTeamsTest()
        {
            var res = _squadsProvider.ProvideSquads(testAlgorithmInput);
            List<Squad> teams = (List<Squad>)res.ToList();

            //just asser counts
            Assert.AreEqual(3, teams.Count());
        }

        [TestCase(0, 2)]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        public void ProvideSquadsTest(int index, int noOfPlayers)
        {
            var res = _squadsProvider.ProvideSquads(testAlgorithmInput);
            List<Squad> teams = (List<Squad>)res.ToList();

            Assert.AreEqual(noOfPlayers, teams[index].Players.Count());
        }
    }
}
