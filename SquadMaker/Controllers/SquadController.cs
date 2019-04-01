using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SquadMakerAlgorithm;

namespace SquadMaker.Controllers
{
    [Route("api/squad")]
    [ApiController]
    public class SquadController : ControllerBase
    {
        private readonly ISquadMaker _squadMaker;
        

        public SquadController()
        {
            _squadMaker = new SquadMakerAlgorithm.SquadMaker();
        }


        [HttpGet("{numberOfSquads}")]
        public ActionResult<IEnumerable<Squad>> GetTeams(int numberOfSquads)
        {
            var res = _squadMaker.Make(numberOfSquads).ToList();
            return Ok(res);
        }

    }
}
