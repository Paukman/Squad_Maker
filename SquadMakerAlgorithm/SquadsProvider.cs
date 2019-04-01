using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMakerAlgorithm
{
    public class SquadsProvider : ISquadsProvider
    {
        private readonly ISquadsAlgorithm _squadsAlgorithm;

        public SquadsProvider()
        {
            _squadsAlgorithm = new SquadsAlgorithm();
        }
        

        public IEnumerable<Squad> ProvideSquads(AlgorithmInput algorithmInput)
        {
            //local copies
            List<SquadPlayer> iterationListOfPlayers = new List<SquadPlayer>(algorithmInput.AllPlayers);
            List<AlgDynamicSequenceModel> localASD = new List<AlgDynamicSequenceModel>(algorithmInput.SequenceData);

            int teamIndex = 1;
            while (iterationListOfPlayers.Count() >= algorithmInput.SquadSize)
            {
                // if bench size is same as remaining, no need to form another team
                if (iterationListOfPlayers.Count() == algorithmInput.BenchSize)
                    break;

                Squad squad = _squadsAlgorithm.CombineSingleSquad(algorithmInput.SquadSize, iterationListOfPlayers, localASD);
                if (squad == null)
                {
                    for (int i = 0; i < localASD.Count(); i++)
                        localASD[i].Deviation = localASD[i].Deviation + 2; //increase the deviation until you get the squad
                    continue;
                }


                foreach (SquadPlayer player in squad.Players) 
                {
                    iterationListOfPlayers.RemoveAll(x => x.Id == player.Id); //remove and repeat the process
                }
                squad.Name = "Squad " + teamIndex++.ToString();
                yield return squad;
            }

            //whatever is left it is bench 
            Squad benchSquad = new Squad() { Players = iterationListOfPlayers };
            benchSquad.Name = "Bench";

            yield return benchSquad; // even if empty...
        }
    }

    
}

