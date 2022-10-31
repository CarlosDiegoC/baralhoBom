using AutoMapper;
using Deck_of_Cards.Context;
using Deck_of_Cards.Domain.Entities;
using Deck_of_Cards.DTO;
using Microsoft.EntityFrameworkCore;

namespace Deck_of_Cards.Repository
{
    public class GameRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GameRepository(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Game> CreateANewGame(CreateANewGame gameDTO)
        {
            var game = _mapper.Map<Game>(gameDTO);
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }
        public async Task<Game> StartANewGame(int playerOneId, int playerTwoId, int playerThreeId, int playerFourId, int gameId)
        {
            Game game = await _context.Games.FindAsync(gameId);           

            Player playerOne = await _context.Players.FindAsync(playerOneId);
            game.Players.Add(playerOne);

            Player playerTwo = await _context.Players.FindAsync(playerTwoId);
            game.Players.Add(playerTwo);

            Player playerThree = await _context.Players.FindAsync(playerThreeId);
            game.Players.Add(playerThree);

            Player playerFour = await _context.Players.FindAsync(playerFourId);
            game.Players.Add(playerFour);

            game.Winner = game.Players.OrderByDescending(player => player.Points).ToList()[0];
            game.Date = DateTime.Now;

            _context.Games.Update(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<ICollection<ConsultGamesDTO>> GetGames()
        {
            var games = await _context.Games.Include(game => game.Winner).ToListAsync();
            return _mapper.Map<ICollection<ConsultGamesDTO>>(games);
        }

    }
}