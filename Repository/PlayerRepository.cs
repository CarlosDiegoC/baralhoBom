using Deck_of_Cards.Context;
using Deck_of_Cards.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Deck_of_Cards.Repository
{
    public class PlayerRepository
    {
        private readonly ApplicationDbContext _context;
        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Player> CreatePlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }
        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }
    }
}