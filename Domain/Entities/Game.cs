using System.ComponentModel.DataAnnotations;

namespace Deck_of_Cards.Domain.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
        public Player Winner { get; set; }

        public Game()
        {
            
        }

    }
}