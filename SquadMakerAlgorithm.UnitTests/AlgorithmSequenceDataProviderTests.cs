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
    public class AlgorithmSequenceDataProviderTests
    {
        private IAlgorithmSequenceDataProvider _algorithmSequenceDataProvider;
        private AlgorithmInput _resultData;

        [SetUp]
        public void ExecuteBeforeEveryTest()
        {
            _algorithmSequenceDataProvider = new AlgorithmSequenceDataProvider();

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

        [TestCase("Checking", 30)]
        [TestCase("Shooting", 66)]
        [TestCase("Skating", 48)]
        public void AlgorithmSequenceDataProviderAverageTest(string skill, int average)
        {
            List<AlgDynamicSequenceModel> sequenceData = new List<AlgDynamicSequenceModel>(_algorithmSequenceDataProvider.ProvideSequenceData(_resultData)).ToList();
            AlgDynamicSequenceModel algSeqData = sequenceData.Find(p => p.Name == skill);

            Assert.AreEqual(average, algSeqData.Average);
        }

        [TestCase("Checking", 2)]
        [TestCase("Shooting", 0)]
        [TestCase("Skating", 1)]
        public void AlgorithmSequenceDataProviderIterationTest(string skill, int iterationOrder)
        {
            List<AlgDynamicSequenceModel> sequenceData = new List<AlgDynamicSequenceModel>(_algorithmSequenceDataProvider.ProvideSequenceData(_resultData)).ToList();
            AlgDynamicSequenceModel algSeqData = sequenceData.Find(p => p.Name == skill);

            Assert.AreEqual(iterationOrder, algSeqData.ItterationOrder);
        }

        [TestCase("Checking", 2.75)]
        [TestCase("Shooting", 0.75)]
        [TestCase("Skating", 1.75)]
        public void AlgorithmSequenceDataProviderDeviatonTest(string skill, double deviation)
        {
            List<AlgDynamicSequenceModel> sequenceData = new List<AlgDynamicSequenceModel>(_algorithmSequenceDataProvider.ProvideSequenceData(_resultData)).ToList();
            AlgDynamicSequenceModel algSeqData = sequenceData.Find(p => p.Name == skill);

            Assert.AreEqual(deviation, algSeqData.Deviation);
        }

        [TestCase("Checking", 2)]
        [TestCase("Shooting", 2)]
        [TestCase("Skating", 2)]
        public void AlgorithmSequenceDataProviderSquadSizeTest(string skill, int squadSize)
        {
            List<AlgDynamicSequenceModel> sequenceData = new List<AlgDynamicSequenceModel>(_algorithmSequenceDataProvider.ProvideSequenceData(_resultData)).ToList();
            AlgDynamicSequenceModel algSeqData = sequenceData.Find(p => p.Name == skill);

            Assert.AreEqual(squadSize, algSeqData.SquadSize);
        }


        [TestCase("Checking", 0)]
        [TestCase("Shooting", 0)]
        [TestCase("Skating", 0)]
        public void AlgorithmSequenceDataProviderAvgAproxTest(string skill, int avgAprox)
        {
            List<AlgDynamicSequenceModel> sequenceData = new List<AlgDynamicSequenceModel>(_algorithmSequenceDataProvider.ProvideSequenceData(_resultData)).ToList();
            AlgDynamicSequenceModel algSeqData = sequenceData.Find(p => p.Name == skill);

            Assert.AreEqual(avgAprox, algSeqData.AvgAprox);
        }

    }
}