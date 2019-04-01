using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SquadMakerAlgorithm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SquadMakerAlgorithm
{
    public class SquadMaker : ISquadMaker
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly IAlgorithmSequenceDataProvider _algSequenceProvider;
        private readonly IAlgorithmInputProvider _internalDataProvider;
        private readonly ISquadsProvider _squadsProvider;
        private readonly ITeamAverageCalculator _iTeamAverageCalculator;

        public SquadMaker()
        {
            _playerProvider = PlayerAccessFactory.GetFilePlayerDataAccessObj();
            _algSequenceProvider = new AlgorithmSequenceDataProvider();
            _internalDataProvider = new AlgorithmInputProvider();
            _squadsProvider = new SquadsProvider();
            _iTeamAverageCalculator = new TeamAverageCalculator();
        }


        public IEnumerable<Squad> Make(int numberOfSquads)
        {

            var allPlayers = new List<SquadPlayer>(_playerProvider.ProvidePlayers()).ToList();

            AlgorithmInput _algorithmInput = new AlgorithmInput();
            _algorithmInput = _internalDataProvider.ProvideAlgorithmInput(numberOfSquads, (List<SquadPlayer>)allPlayers);

            var sequenceData = new List<AlgDynamicSequenceModel>(_algSequenceProvider.ProvideSequenceData(_algorithmInput));

            _algorithmInput.AllPlayers = allPlayers;
            _algorithmInput.SequenceData = sequenceData;

            var squads = new List<Squad>(_squadsProvider.ProvideSquads(_algorithmInput)).ToList();
            foreach (Squad squad in (List<Squad>)squads)
            {
                if (squad.Name.Equals("bench", StringComparison.OrdinalIgnoreCase))
                    yield return squad;
                else
                {
                    _iTeamAverageCalculator.CalculateAverage(squad);
                    yield return squad;
                }
            }
        }
    }
}
