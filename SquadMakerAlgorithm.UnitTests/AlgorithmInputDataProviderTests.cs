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
    public class AlgorithmInputDataProviderTests
    {
        private IAlgorithmInputProvider _internalModelDataProvider;
        private List<SquadPlayer> _testlist;
        private AlgorithmInput _resultData;

        [SetUp]
        public void ExecuteBeforeEveryTest()
        {
            _internalModelDataProvider = new AlgorithmInputProvider();
            _testlist = new List<SquadPlayer>()
        {
            new SquadPlayer(){Id = "1", Name="Sam Smith",     Checking = 20, Shooting = 35, Skating = 50 },
            new SquadPlayer(){Id = "2", Name="Sasa Trkulja",  Checking = 50, Shooting = 90, Skating = 45 },
            new SquadPlayer(){Id = "3", Name="Teddy Trkulja", Checking = 20, Shooting = 25, Skating = 50 },
            new SquadPlayer(){Id = "4", Name="Adam Trkulja",  Checking = 40, Shooting = 80, Skating = 25 },
            new SquadPlayer(){Id = "5", Name="Sandra Trkulja",Checking = 20, Shooting =100, Skating = 70 }
        };

            _resultData = new AlgorithmInput()
            {
                SquadSize = 2,
                AvgChecking = 30,
                AvgShooting = 66,
                AvgSkating = 48,
                BenchSize = 1,
                InitialDeviation = 0.75,
                NumberOfPlayers = 5,
                NumberOfSquads = 2
            };
        }

        [TestCase]
        public void ProvideInternalModelDataAvgCheckingTest()
        {
            AlgorithmInput _internalModelData = _internalModelDataProvider.ProvideAlgorithmInput(2, _testlist);
            Assert.AreEqual(_resultData.AvgChecking, _internalModelData.AvgChecking);
        }

        [TestCase]
        public void ProvideInternalModelDataAvgShootingTest()
        {
            AlgorithmInput _internalModelData = _internalModelDataProvider.ProvideAlgorithmInput(2, _testlist);

            Assert.AreEqual(_resultData.AvgShooting, _internalModelData.AvgShooting);
        }

        [TestCase]
        public void ProvideInternalModelDataAvgSkatingTest()
        {
            AlgorithmInput _internalModelData = _internalModelDataProvider.ProvideAlgorithmInput(2, _testlist);
            Assert.AreEqual(_resultData.AvgSkating, _internalModelData.AvgSkating);
        }

        [TestCase]
        public void ProvideInternalModelDataNumberOfPlayersTest()
        {
            AlgorithmInput _internalModelData = _internalModelDataProvider.ProvideAlgorithmInput(2, _testlist);
            Assert.AreEqual(_resultData.NumberOfPlayers, _internalModelData.NumberOfPlayers);
        }

        [TestCase]
        public void ProvideInternalModelDataBenchSizeTest()
        {
            AlgorithmInput _internalModelData = _internalModelDataProvider.ProvideAlgorithmInput(2, _testlist);
            Assert.AreEqual(_resultData.BenchSize, _internalModelData.BenchSize);
        }

        [TestCase]
        public void ProvideInternalModelDataInitialDeviationTest()
        {
            AlgorithmInput _internalModelData = _internalModelDataProvider.ProvideAlgorithmInput(2, _testlist);
            Assert.AreEqual(_resultData.InitialDeviation, _internalModelData.InitialDeviation);
        }

        [TestCase]
        public void ProvideInternalModelDataNumberOfSquadsTest()
        {
            AlgorithmInput _internalModelData = _internalModelDataProvider.ProvideAlgorithmInput(2, _testlist);
            Assert.AreEqual(_resultData.NumberOfSquads, _internalModelData.NumberOfSquads);
        }

        [TestCase]
        public void ProvideInternalModelDataSquadSizeTest()
        {
            AlgorithmInput _internalModelData = _internalModelDataProvider.ProvideAlgorithmInput(2, _testlist);
            Assert.AreEqual(_resultData.SquadSize, _internalModelData.SquadSize);
        }

        [TestCase]
        public void ProvideInternalModelDataAvgAproxCheTest()
        {
            AlgorithmInput _internalModelData = _internalModelDataProvider.ProvideAlgorithmInput(2, _testlist);
            Assert.AreEqual(0, _internalModelData.AvgAproxChe);
        }

        [TestCase]
        public void ProvideInternalModelDataAvgAproxSkaTest()
        {
            AlgorithmInput _internalModelData = _internalModelDataProvider.ProvideAlgorithmInput(2, _testlist);
            Assert.AreEqual(0, _internalModelData.AvgAproxSka);
        }

        [TestCase]
        public void ProvideInternalModelDataAvgAproxShoTest()
        {
            AlgorithmInput _internalModelData = _internalModelDataProvider.ProvideAlgorithmInput(2, _testlist);
            Assert.AreEqual(0, _internalModelData.AvgAproxSho);
        }
        
    }
}