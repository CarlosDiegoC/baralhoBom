using Deck_of_Cards.Domain.Entities;
using Deck_of_Cards.DTO;
using Deck_of_Cards.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Deck_of_Cards.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {        
        private readonly GameRepository _gameRepository;
        public GamesController(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Game>> CreateANewGame(CreateANewGame gameDTO)
        {         
            var game = await _gameRepository.CreateANewGame(gameDTO);
            return Ok(game);
        }    
        
        [HttpPut]
        public async Task<ActionResult<Game>> StartANewGame(int playerOneId, int playerTwoId, int playerThreeId, int playerFourId, int gameId)
        {         
            Game gameResult = await _gameRepository.StartANewGame(playerOneId, playerTwoId, playerThreeId, playerFourId, gameId);
            return Ok(gameResult);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Game>>> GetGames()
        {
            var games = await _gameRepository.GetGames();
            return Ok(games);
        }
    }
}