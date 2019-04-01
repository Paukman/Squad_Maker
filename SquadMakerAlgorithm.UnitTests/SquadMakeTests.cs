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
    class SquadMakeTests
    {
        private ISquadMaker _make;

        [SetUp]
        public void ExecuteBeforeEveryTest()
        {
            _make = new SquadMaker();
        }

        [TestCase(4, 5)]
        [TestCase(5, 6)]
        [TestCase(6, 7)]
        [TestCase(7, 8)]
        [TestCase(8, 9)]
        [TestCase(9, 10)]
        [TestCase(10, 11)]
        public void SquadMakerTeamsCreatedTests(int numberOfTeams, int teamsCreated)
        {
            List<Squad> res = new List<Squad>(_make.Make(numberOfTeams).ToList());
            Assert.AreEqual(teamsCreated, res.Count());
        }

        [TestCase(4, 11)]
        [TestCase(5, 9)]
        [TestCase(6, 7)]
        [TestCase(7, 6)]
        [TestCase(8, 6)]
        [TestCase(9, 5)]
        [TestCase(10, 5)]
        public void SquadMakerSizeOfTeamsTests(int numberOfTeams, int sizeOfteams)
        {
            List<Squad> res = new List<Squad>(_make.Make(numberOfTeams).ToList());
            foreach (Squad squad in res)
            {
                if (!squad.Name.Equals("bench", StringComparison.OrdinalIgnoreCase))
                    Assert.AreEqual(sizeOfteams, squad.Players.Count());
            }
        }

        [TestCase(4, 0)]
        [TestCase(5, 0)]
        [TestCase(6, 4)]
        [TestCase(7, 5)]
        [TestCase(8, 0)]
        [TestCase(9, 4)]
        [TestCase(10, 0)]
        public void SquadMakerBenchSizeTests(int numberOfTeams, int benchSize)
        {
            List<Squad> res = new List<Squad>(_make.Make(numberOfTeams).ToList());
            Squad squad = res.FirstOrDefault(p => p.Name.Equals("bench", StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(benchSize, squad.Players.Count());
        }
    }
}
