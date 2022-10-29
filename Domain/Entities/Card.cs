using System.ComponentModel.DataAnnotations;

namespace Deck_of_Cards.Domain.Entities
{
    public class Card
    {
        [Key]
        public string Code { get; set; }
        public string Image { get; set; }
        public string Value { get; set; }
        public string Suit { get; set; }
    }
}