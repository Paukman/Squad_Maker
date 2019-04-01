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
    public class FilePlayerProviderUnitTests
    {
        private FilePlayerProvider _filePlayerProvider;
        

        [SetUp]
        public void ExecuteBeforeEveryTest()
        {
            _filePlayerProvider = new FilePlayerProvider();
        }


        [TestCase]
        public void ProvidePlayersTest()
        {
            List<SquadPlayer> ret = new List<SquadPlayer>(_filePlayerProvider.ProvidePlayers());
            Assert.AreEqual(40, ret.Count());

        }
    }
}