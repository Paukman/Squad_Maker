using SquadMakerAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMakerAlgorithm
{
    

    public class AlgorithmInputProvider : IAlgorithmInputProvider
    {
        
        public AlgorithmInput ProvideAlgorithmInput(int numberOfSquads, List<SquadPlayer> allPlayers)
        {
            AlgorithmInput algorithmInputData = new AlgorithmInput();

            if (numberOfSquads <= 0)
                throw new System.ArgumentException("Number of squads cannot be null.");

            algorithmInputData.NumberOfPlayers = allPlayers.Count();
            algorithmInputData.SquadSize = allPlayers.Count() / numberOfSquads;


            if (algorithmInputData.NumberOfPlayers < algorithmInputData.SquadSize)
                throw new System.ArgumentException("Number of players cannot be smaller than number of teams.");


            algorithmInputData.NumberOfSquads = numberOfSquads;
            algorithmInputData.BenchSize = algorithmInputData.NumberOfPlayers - (algorithmInputData.SquadSize * numberOfSquads);

            algorithmInputData.AvgShooting = allPlayers.Sum(p => p.Shooting) / algorithmInputData.NumberOfPlayers;
            algorithmInputData.AvgSkating = allPlayers.Sum(p => p.Skating) / algorithmInputData.NumberOfPlayers;
            algorithmInputData.AvgChecking = allPlayers.Sum(p => p.Checking) / algorithmInputData.NumberOfPlayers;

            algorithmInputData.InitialDeviation = 0.75;

            algorithmInputData.AvgAproxChe = 0;
            algorithmInputData.AvgAproxSka = 0;
            algorithmInputData.AvgAproxSho = 0;

            return algorithmInputData;

        }
    }
}
