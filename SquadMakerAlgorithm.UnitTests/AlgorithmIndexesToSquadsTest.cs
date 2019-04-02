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

        private AlgorithmIndexesToSquads _algorithmIndexesToSquads;
        private List<SquadPlayer> _testlist;

        [SetUp]
        public void ExecuteBeforeEveryTest()
        {



            _testlist = new List<SquadPlayer>()
        {
            new SquadPlayer(){Id = "1", Name="Sam Smith",     Checking = 20, Shooting = 35, Skating = 50 },
            new SquadPlayer(){Id = "2", Name="Sasa Trkulja",  Checking = 50, Shooting = 90, Skating = 45 },
            new SquadPlayer(){Id = "3", Name="Teddy Trkulja", Checking = 20, Shooting = 25, Skating = 50 },
            new SquadPlayer(){Id = "4", Name="Adam Trkulja",  Checking = 40, Shooting = 80, Skating = 25 },
            new SquadPlayer(){Id = "5", Name="Sandra Trkulja",Checking = 20, Shooting =100, Skating = 70 }
        };





            _algorithmIndexesToSquads = new AlgorithmIndexesToSquads();
        }


        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 3 }, 2)]
        [TestCase(new int[] { 1, 3, 4 }, 3)]
        [TestCase(new int[] { 0, 1, 2, 3 }, 4)]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 5)]
        public void AlgorithmIndexesToSquadsCountTest(int[] index, int count)
        {
            //Squad squad = new Squad();
            Squad _testSquad = new Squad() { Players = new List<SquadPlayer>() };
            _testSquad.Players.Add(_testlist[0]);
            Squad squad = _algorithmIndexesToSquads.ConvertResultIndexesToIds(index, _testlist);
            Assert.AreEqual(count, squad.Players.Count);
        }

        [TestCase(new int[] { 1, 3 }, 0, 1)]
        [TestCase(new int[] { 1, 3 }, 1, 3)]
        [TestCase(new int[] { 1, 2, 4 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 4 }, 1, 2)]
        [TestCase(new int[] { 1, 2, 4 }, 2, 4)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 0, 0)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 1, 2)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 2, 3)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 3, 4)]
        public void AlgorithmIndexesToSquadsIDTest(int[] index, int origIndex, int retIndex)
        {
            Squad squad = _algorithmIndexesToSquads.ConvertResultIndexesToIds(index, _testlist);
            Assert.AreEqual(squad.Players[origIndex].Id, _testlist[retIndex].Id);
        }

        [TestCase(new int[] { 1, 3 }, 0, 1)]
        [TestCase(new int[] { 1, 3 }, 1, 3)]
        [TestCase(new int[] { 1, 2, 4 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 4 }, 1, 2)]
        [TestCase(new int[] { 1, 2, 4 }, 2, 4)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 0, 0)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 1, 2)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 2, 3)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 3, 4)]
        public void AlgorithmIndexesToSquadsNameTest(int[] index, int origIndex, int retIndex)
        {
            Squad squad = _algorithmIndexesToSquads.ConvertResultIndexesToIds(index, _testlist);
            Assert.AreEqual(squad.Players[origIndex].Name, _testlist[retIndex].Name);
        }

        [TestCase(new int[] { 1, 3 }, 0, 1)]
        [TestCase(new int[] { 1, 3 }, 1, 3)]
        [TestCase(new int[] { 1, 2, 4 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 4 }, 1, 2)]
        [TestCase(new int[] { 1, 2, 4 }, 2, 4)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 0, 0)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 1, 2)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 2, 3)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 3, 4)]
        public void AlgorithmIndexesToSquadsCheckingTest(int[] index, int origIndex, int retIndex)
        {
            Squad squad = _algorithmIndexesToSquads.ConvertResultIndexesToIds(index, _testlist);
            Assert.AreEqual(squad.Players[origIndex].Checking, _testlist[retIndex].Checking);
        }


        [TestCase(new int[] { 1, 3 }, 0, 1)]
        [TestCase(new int[] { 1, 3 }, 1, 3)]
        [TestCase(new int[] { 1, 2, 4 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 4 }, 1, 2)]
        [TestCase(new int[] { 1, 2, 4 }, 2, 4)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 0, 0)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 1, 2)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 2, 3)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 3, 4)]
        public void AlgorithmIndexesToSquadsShootingTest(int[] index, int origIndex, int retIndex)
        {
            Squad squad = _algorithmIndexesToSquads.ConvertResultIndexesToIds(index, _testlist);
            Assert.AreEqual(squad.Players[origIndex].Shooting, _testlist[retIndex].Shooting);
        }

        [TestCase(new int[] { 1, 3 }, 0, 1)]
        [TestCase(new int[] { 1, 3 }, 1, 3)]
        [TestCase(new int[] { 1, 2, 4 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 4 }, 1, 2)]
        [TestCase(new int[] { 1, 2, 4 }, 2, 4)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 0, 0)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 1, 2)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 2, 3)]
        [TestCase(new int[] { 0, 2, 3, 4 }, 3, 4)]
        public void AlgorithmIndexesToSquadsSkatingTest(int[] index, int origIndex, int retIndex)
        {
            Squad squad = _algorithmIndexesToSquads.ConvertResultIndexesToIds(index, _testlist);
            Assert.AreEqual(squad.Players[origIndex].Skating, _testlist[retIndex].Skating);
        }

    }
}
