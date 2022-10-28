using Deck_of_Cards.Domain.Entities;

namespace Deck_of_Cards.Repository
{
    public interface IPlayerRepository
    {
        public Task<IEnumerable<Player>> GetPlayers();
        public Task<Player> GetPlayerById();
        public Task<Player> CreatePlayer();
        public Task<Player> UpdatePlayer();
        public Task DeletePlayer();
    }
}