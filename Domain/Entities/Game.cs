using System.ComponentModel.DataAnnotations;

namespace Deck_of_Cards.Domain.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string DeckId { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public Player Winner { get; set; }
    }
}