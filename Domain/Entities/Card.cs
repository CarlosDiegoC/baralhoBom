namespace Deck_of_Cards.Domain.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public string Value { get; set; }
        public string Suit { get; set; }
        public int PlayerId { get; set; }
    }
}