using AutoMapper;
using Deck_of_Cards.Context;
using Deck_of_Cards.Domain.Entities;
using Deck_of_Cards.DTO;
using Microsoft.EntityFrameworkCore;

namespace Deck_of_Cards.Repository
{
    public class PlayerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PlayerRepository(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Player> CreatePlayer(CreateANewPlayer playerDTO)
        {
            var player = _mapper.Map<Player>(playerDTO);
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