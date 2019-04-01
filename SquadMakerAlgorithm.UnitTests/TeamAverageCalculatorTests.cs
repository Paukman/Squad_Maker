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
    class TeamAverageCalculatorTests
    {
        private ITeamAverageCalculator _teamAverageCalculator;
        private Squad _squad;
        private Squad _squadEmpty;
        private Squad _squadNoList;


        [SetUp]
        public void ExecuteBeforeEveryTest()
        {
            _teamAverageCalculator = new TeamAverageCalculator();
            List<SquadPlayer> testPlayerList = new List<SquadPlayer>()
            {
                new SquadPlayer(){Id = "1", Name="Alex Carney", Checking = 92, Shooting = 98, Skating = 90 },
                new SquadPlayer(){Id = "2", Name="Bob Smith",   Checking = 50, Shooting = 60, Skating = 80 },
                new SquadPlayer(){Id = "3", Name="Roy Talbot",  Checking = 20, Shooting = 85, Skating = 60 },
                new SquadPlayer(){Id = "4", Name="Jill White",  Checking = 60, Shooting = 90, Skating = 70 },
                new SquadPlayer(){Id = "5", Name="Jennifer Wu", Checking = 100, Shooting = 55, Skating = 94 }
            };
            _squad = new Squad() { Players = testPlayerList };
            _squadEmpty = new Squad() { Players = new List<SquadPlayer>() };
            _squadNoList = new Squad();
        }


        [TestCase(6)]
        public void CalculateAverageNoOfPlayersTests(int noOfPlayer)
        {

            _teamAverageCalculator.CalculateAverage(_squad);
            Assert.AreEqual(noOfPlayer, _squad.Players.Count());
        }

        [TestCase("Checking", 64)]
        [TestCase("Shooting", 77)]
        [TestCase("Skating", 78)]
        public void CalculateAverageSkillsTests(string skill, int average)
        {
            _teamAverageCalculator.CalculateAverage(_squad);
            SquadPlayer player = _squad.Players.FirstOrDefault(p => p.Name.Contains("Average Skills"));
            int resAverage = (skill == "Checking") ? player.Checking : (skill == "Shooting" ? player.Shooting : player.Skating);
            Assert.AreEqual(average, resAverage);
        }

        [TestCase]
        public void CalculateAverageTestsFail()
        {
            _teamAverageCalculator.CalculateAverage(_squadEmpty);
            Assert.AreEqual(0, _squadEmpty.Players.Count());
        }

        [TestCase]
        public void CalculateAverageTestsNoList()
        {
            Assert.Throws<System.ArgumentNullException>(() => _teamAverageCalculator.CalculateAverage(_squadNoList));
        }
    }
}
