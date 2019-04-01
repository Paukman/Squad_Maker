
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
    class AlgorithmCheckMeanValueTest
    {

        private AlgorithmCheckMeanValue _algorithmCheckMeanValue;
        private List<SquadPlayer> _testlist;
        private List<AlgDynamicSequenceModel> _asdList;

        [SetUp]
        public void ExecuteBeforeEveryTest()
        {


            _testlist = new List<SquadPlayer>()
        {
            new SquadPlayer(){Id = "1", Name="Alex Carney", Checking = 92, Shooting = 98, Skating = 90 },
            new SquadPlayer(){Id = "2", Name="Bob Smith",   Checking = 50, Shooting = 60, Skating = 80 },
            new SquadPlayer(){Id = "3", Name="Roy Talbot",  Checking = 20, Shooting = 85, Skating = 60 },
            new SquadPlayer(){Id = "4", Name="Jill White",  Checking = 60, Shooting = 90, Skating = 70 },
            new SquadPlayer(){Id = "5", Name="Jennifer Wu", Checking = 100, Shooting = 55, Skating = 94 }
        };


            _asdList = new List<AlgDynamicSequenceModel>()
        {
            new AlgDynamicSequenceModel(){Average = 64, Deviation = 5, ItterationOrder = 0,  Name = "Checking", AvgAprox = 0},
            new AlgDynamicSequenceModel(){Average = 65, Deviation = 5, ItterationOrder = 1,  Name = "Shooting", AvgAprox = 0},
            new AlgDynamicSequenceModel(){Average = 78, Deviation = 5, ItterationOrder = 2,  Name = "Skating", AvgAprox = 0}
        };

            _algorithmCheckMeanValue = new AlgorithmCheckMeanValue();
        }


        [TestCase(new int[] { 0, 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 2, 3 })]
        [TestCase(new int[] { 0, 3 })]
        [TestCase(new int[] { 0, 4 })]
        [TestCase(new int[] { 0, 1,2 })]
        [TestCase(new int[] { 0, 1, 3 })]
        [TestCase(new int[] { 0, 2, 2 })]
        [TestCase(new int[] { 0, 3, 4 })]
        [TestCase(new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] {0, 1, 3, 4 })]
        [TestCase(new int[] { 0, 1,2, 3, 4 })]
        public void AlgorithmCheckMeanValueCheckingPassTest(int [] players)
        {
            int average = _testlist.Where((item, index) => players.Contains(index))
                .Select(p => p.Checking).Sum()/ players.Count();
            _asdList[0].Average = average;
            _asdList[0].SquadSize = players.Count();
            var ret = _algorithmCheckMeanValue.CheckSkillMeanValue(players, _testlist, _asdList[0]);
            Assert.AreEqual(true, ret);

        }

        [TestCase(new int[] { 0, 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 2, 3 })]
        [TestCase(new int[] { 0, 3 })]
        [TestCase(new int[] { 0, 4 })]
        [TestCase(new int[] { 0, 1, 2 })]
        [TestCase(new int[] { 0, 1, 3 })]
        [TestCase(new int[] { 0, 2, 2 })]
        [TestCase(new int[] { 0, 3, 4 })]
        [TestCase(new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 0, 1, 3, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 })]
        public void AlgorithmCheckMeanValueCheckingFailTest(int[] players)
        {
            int average = _testlist.Where((item, index) => players.Contains(index))
                .Select(p => p.Checking).Sum() / players.Count();
            _asdList[0].Average = average+6;
            _asdList[0].SquadSize = players.Count();
            var ret = _algorithmCheckMeanValue.CheckSkillMeanValue(players, _testlist, _asdList[0]);
            Assert.AreEqual(false, ret);

        }


        [TestCase(new int[] { 0, 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 2, 3 })]
        [TestCase(new int[] { 0, 3 })]
        [TestCase(new int[] { 0, 4 })]
        [TestCase(new int[] { 0, 1, 2 })]
        [TestCase(new int[] { 0, 1, 3 })]
        [TestCase(new int[] { 0, 2, 2 })]
        [TestCase(new int[] { 0, 3, 4 })]
        [TestCase(new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 0, 1, 3, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 })]
        public void AlgorithmCheckMeanValueShootingPassTest(int[] players)
        {
            int average = _testlist.Where((item, index) => players.Contains(index))
                .Select(p => p.Shooting).Sum() / players.Count();
            _asdList[1].Average = average;
            _asdList[1].SquadSize = players.Count();
            var ret = _algorithmCheckMeanValue.CheckSkillMeanValue(players, _testlist, _asdList[1]);
            Assert.AreEqual(true, ret);

        }
        [TestCase(new int[] { 0, 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 2, 3 })]
        [TestCase(new int[] { 0, 3 })]
        [TestCase(new int[] { 0, 4 })]
        [TestCase(new int[] { 0, 1, 2 })]
        [TestCase(new int[] { 0, 1, 3 })]
        [TestCase(new int[] { 0, 2, 2 })]
        [TestCase(new int[] { 0, 3, 4 })]
        [TestCase(new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 0, 1, 3, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 })]
        public void AlgorithmCheckMeanValueShootingFailTest(int[] players)
        {
            int average = _testlist.Where((item, index) => players.Contains(index))
                .Select(p => p.Shooting).Sum() / players.Count();
            _asdList[1].Average = average + 6;
            _asdList[1].SquadSize = players.Count();
            var ret = _algorithmCheckMeanValue.CheckSkillMeanValue(players, _testlist, _asdList[1]);
            Assert.AreEqual(false, ret);

        }
        [TestCase(new int[] { 0, 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 2, 3 })]
        [TestCase(new int[] { 0, 3 })]
        [TestCase(new int[] { 0, 4 })]
        [TestCase(new int[] { 0, 1, 2 })]
        [TestCase(new int[] { 0, 1, 3 })]
        [TestCase(new int[] { 0, 2, 2 })]
        [TestCase(new int[] { 0, 3, 4 })]
        [TestCase(new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 0, 1, 3, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 })]
        public void AlgorithmCheckMeanValueSkatingPassTest(int[] players)
        {
            int average = _testlist.Where((item, index) => players.Contains(index))
                .Select(p => p.Skating).Sum() / players.Count();
            _asdList[2].Average = average;
            _asdList[2].SquadSize = players.Count();
            var ret = _algorithmCheckMeanValue.CheckSkillMeanValue(players, _testlist, _asdList[2]);
            Assert.AreEqual(true, ret);

        }

        [TestCase(new int[] { 0, 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 2, 3 })]
        [TestCase(new int[] { 0, 3 })]
        [TestCase(new int[] { 0, 4 })]
        [TestCase(new int[] { 0, 1, 2 })]
        [TestCase(new int[] { 0, 1, 3 })]
        [TestCase(new int[] { 0, 2, 2 })]
        [TestCase(new int[] { 0, 3, 4 })]
        [TestCase(new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 0, 1, 3, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 })]
        public void AlgorithmCheckMeanValueSkatingFailTest(int[] players)
        {
            int average = _testlist.Where((item, index) => players.Contains(index))
                .Select(p => p.Skating).Sum() / players.Count();
            _asdList[2].Average = average + 6;
            _asdList[2].SquadSize = players.Count();
            var ret = _algorithmCheckMeanValue.CheckSkillMeanValue(players, _testlist, _asdList[2]);
            Assert.AreEqual(false, ret);

        }
    }
}
