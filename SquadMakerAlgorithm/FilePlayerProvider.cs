using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SquadMakerAlgorithm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SquadMakerAlgorithm
{
    public class FilePlayerProvider : IPlayerProvider
    {
        public IEnumerable<SquadPlayer> ProvidePlayers()
        {
            string filePath = "players.json";
            JObject my_obj = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(filePath));
            foreach (KeyValuePair<string, JToken> sub_obj in my_obj) 
            {
                foreach (JObject player in sub_obj.Value)
                {
                    string id = (string)player["_id"];
                    string name = (string)player["firstName"] + " " + (string)player["lastName"];
                    int[] skills = new int[3]; //shooting, skating, checking
                    int index = 0;
                    foreach (JObject skill in player["skills"])
                        skills[index++] = (int)skill["rating"];

                    SquadPlayer squadPlayer = new SquadPlayer()
                    { Id = id, Name = name, Shooting = skills[0], Skating = skills[1], Checking = skills[2] };

                    yield return squadPlayer;
                }
            }
        }
    }
}
