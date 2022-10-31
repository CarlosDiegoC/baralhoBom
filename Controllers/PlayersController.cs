using Deck_of_Cards.Domain.Entities;
using Deck_of_Cards.DTO;
using Deck_of_Cards.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Deck_of_Cards.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerRepository _playerRepository;
        public PlayersController(PlayerRepository playerRepository) 
        {
            _playerRepository = playerRepository;
        }

        [HttpPost]
        public async Task<Player> CreatePlayer(CreateANewPlayer playerDTO)
        {
            return await _playerRepository.CreatePlayer(playerDTO);
        }

        [HttpGet]
        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _playerRepository.GetPlayers();
        }
    }
}