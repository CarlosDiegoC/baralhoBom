using System.ComponentModel.DataAnnotations;

namespace Deck_of_Cards.Domain.Entities
{
    public class Deck
    {
        [Key]
        public string Deck_id { get; set; }
        public bool Shuffled { get; set; }
        public int Remaining { get; set; }
    }
}