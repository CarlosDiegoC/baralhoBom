namespace Deck_of_Cards.Domain.Entities
{
    public class Deck
    {
        public string deck_id { get; set; }
        public bool shuffled { get; set; }
        public int remaining { get; set; }
    }
}