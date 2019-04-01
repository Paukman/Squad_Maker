using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMakerAlgorithm
{
    
    
    public class TeamAverageCalculator : ITeamAverageCalculator
    {
        public void CalculateAverage(Squad squad)
        {
            if (squad.Players.Count() == 0)
                return;

            if (squad.Players.Count() < 0)
                throw new System.ArgumentException("Number of players in squad is :" + squad.Players.Count());

            int shootingAverage = squad.Players.Sum(p => p.Shooting) / squad.Players.Count();
            int skatingAverage = squad.Players.Sum(p => p.Skating) / squad.Players.Count();
            int checkingAverage = squad.Players.Sum(p => p.Checking) / squad.Players.Count();

            SquadPlayer player = new SquadPlayer()
            {
                Name = "Average Skills:",
                Id = Guid.NewGuid().ToString("N"),
                Skating = skatingAverage,
                Shooting = shootingAverage,
                Checking = checkingAverage
            };

            squad.Players.Add(player);
        }
    }
}
