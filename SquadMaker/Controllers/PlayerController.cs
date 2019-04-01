using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using SquadMakerAlgorithm;

namespace SquadMaker.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerProvider _playerProvider;


        public PlayerController()
        {
            _playerProvider = PlayerAccessFactory.GetFilePlayerDataAccessObj();
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<SquadPlayer>> GetTodoItems()
        {
            var res = _playerProvider.ProvidePlayers().ToList();
            return Ok(res);
        }

        
    }
}